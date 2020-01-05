using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using MalhaToByte.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConvertToByte
{
    class Program18
    {
        static void Main(string[] args)
        {
            DataTable table = null;
            DataRow dataRow = null;

            Console.WriteLine("Lendo contratos...");
            string PathFileCompany = @"C:\@TombamentoV1_01\TOMBAMENTOS\";
            try
            {
                table = CriaTabelaPdf();

                int contador = 0, totalContratos = 0;
                IEnumerable<string> fileContract = Directory.EnumerateFiles(PathFileCompany, "*_25.pdf", SearchOption.AllDirectories);
                FileInfo _contract = null;

                fileContract.ToList().ForEach(w =>
                {
                    try
                    {
                        _contract = new FileInfo(w);

                        dataRow = table.NewRow();

                        dataRow["ContractName"] = _contract.Name.Split('_')[0];
                        dataRow["FileEncryption"] = File.ReadAllBytes(_contract.FullName);
                        dataRow["DateInput"] = DateTime.Now;

                        table.Rows.Add(dataRow);
                        contador++;
                        _contract = null;

                        if (contador == 10000)
                        {
                            totalContratos += contador;

                            Console.WriteLine($"Aguarde...\n\nTotal Arnazenado  {totalContratos} \n");
                            Cnn.FileStores(table);
                            contador = 0;
                        }


                    }
                    catch (Exception exload)
                    {
                        Console.WriteLine(exload.Message);
                        Console.ReadKey();
                    }

                   

                });


                if (contador > 0)
                {
                    totalContratos += contador;

                    Cnn.FileStores(table);
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
            table.Columns.Add("ContractName", typeof(string));
            table.Columns.Add("FileEncryption", typeof(byte[]));
            table.Columns.Add("DateInput", typeof(DateTime));

            return table;
        }
    }
    
}
