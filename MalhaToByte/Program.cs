using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using MalhaToByte.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MalhaToByte
{
    class Program
    {
       
        static void Main(string[] args)
        {
            List<string> diretorios = new List<string>();

            DataTable table = null;
            DataRow dataRow = null;

            Console.WriteLine("Lendo contratos...");


            string PathFileCompany = @"C:\@TombamentoV1_01\TOMBAMENTOS\TOMBAMENTO2020-02-14\2020-02-12\T004Z20";
            try
            {
                table = CriaTabelaPdf();

                string newNameContract = string.Empty;
                int contador = 0, totalContratos = 0, sequencia = 0;
                string pagina, _personDocument;
                bool isDateContract;
                List<string> arrayLine = new List<string>();

                IEnumerable<string> fileContract = Directory.EnumerateFiles(PathFileCompany,"*_16.pdf", SearchOption.AllDirectories);

                FileCompress fileCompress = null;

                   fileContract.ToList().ForEach(w =>
                   {

                       fileCompress = new FileCompress();
                       try
                       {
                           isDateContract = false;
                           FileInfo _contract = new FileInfo(w);
                           using (PdfReader reader = new PdfReader(w))
                           {
                               ITextExtractionStrategy its;
                               pagina = _personDocument = string.Empty;

                               for (int i = 1; i <= reader.NumberOfPages; i++)
                               {
                                   its = new LocationTextExtractionStrategy();
                                   pagina = PdfTextExtractor.GetTextFromPage(reader, i, its).Trim();

                                   using (StringReader strReader = new StringReader(pagina))
                                   {
                                       string line = string.Empty;

                                       while ((line = strReader.ReadLine()) != null)
                                       {
                                           arrayLine = line.Split(' ').ToList();

                                           if (!isDateContract)
                                           {
                                               if (!arrayLine.Any(c => Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\-\d{2}$)") || Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\/\d{4}\-\d{2}$)"))) continue;

                                               sequencia = arrayLine.ToList().FindIndex(c => Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\-\d{2}$)") || Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\/\d{4}\-\d{2}$)"));

                                               fileCompress.PersonName = string.Join(" ", arrayLine.Take((sequencia - 1)).ToArray());
                                               fileCompress.NumberContract = _contract.Name.Split('_')[0];

                                               _personDocument = arrayLine.FirstOrDefault(c => Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\-\d{2}$)") || Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\/\d{4}\-\d{2}$)"));
                                               fileCompress.PersonDocument = Regex.Replace(_personDocument, "[^0-9$]", string.Empty);
                                               isDateContract = true;
                                               continue;
                                           }
                                           else
                                           {
                                               if (!arrayLine.Any(c => Regex.IsMatch(c, @"(^\d{2}/\d{2}/\d{4}$)"))) continue;

                                               fileCompress.DateContract = Convert.ToDateTime(arrayLine.Find(c => Regex.IsMatch(c, @"(^\d{2}/\d{2}/\d{4}$)")));
                                               fileCompress.TypeContract = "L";
                                               fileCompress.EncryptedFile = File.ReadAllBytes(_contract.FullName);
                                           }
                                           break;
                                       }
                                   }

                                   if (!string.IsNullOrWhiteSpace(_personDocument))
                                       break;
                               }


                               dataRow = table.NewRow();

                               dataRow["TypeContract"] = fileCompress.TypeContract.Trim();
                               dataRow["PersonName"] = fileCompress.PersonName.Length > 100 ? fileCompress.PersonName.Substring(0,100) : fileCompress.PersonName;
                               dataRow["PersonDocument"] = fileCompress.PersonDocument;
                               dataRow["NumberContract"] = fileCompress.NumberContract;
                               dataRow["DateContract"] = fileCompress.DateContract;
                               dataRow["DateInclude"] = DateTime.Now;
                               dataRow["EncryptedFile"] = fileCompress.EncryptedFile;

                               table.Rows.Add(dataRow);

                           }
                           contador++;
                           _contract = null;

                           if (contador == 5000)
                           {
                               totalContratos += contador;

                               Cnn.FileStores(table, "FileSafe16");
                               Console.WriteLine($"Aguarde...\n\nTotal Arnazenado  {totalContratos} \n");
                               contador = 0;
                               table.Rows.Clear();
                           }


                       }
                       catch (iTextSharp.text.exceptions.InvalidPdfException exload)
                       {
                           Console.WriteLine(exload.Message);
                       }

                       catch (PdfException exload)
                       {
                           Console.WriteLine(exload.Message);
                       }

                   });


                if (contador > 0)
                {
                    totalContratos += contador;

                    Cnn.FileStores(table, "FileSafe16");
                    contador = 0;
                    table = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            Console.WriteLine("\n\n\n CONCLUIDO");
            Console.ReadKey();

        }


        private static DataTable CriaTabelaPdf()
        {
            var table = new DataTable();
            table.Columns.Add("PersonName", typeof(string));
            table.Columns.Add("PersonDocument", typeof(string));
            table.Columns.Add("NumberContract", typeof(string));
            table.Columns.Add("DateContract", typeof(DateTime));
           // table.Columns.Add("DateInclude", typeof(DateTime));
           // table.Columns.Add("EncryptedFile", typeof(byte[]));

            return table;
        }

    }
}
