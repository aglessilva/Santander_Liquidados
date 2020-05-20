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
            string _tableBook = "FileSafe25";

            Console.WriteLine("Lendo contratos...");
            string PathFileCompany = @"C:\@TombamentoV1_01\TOMBAMENTOS\TOMBAMENTO2020-02-14\2020-02-12\";
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

                        dataRow["TypeContract"] = 'P';
                        dataRow["NumberContract"] = _contract.Name.Split('_')[0];
                        dataRow["EncryptedFile"] = File.ReadAllBytes(_contract.FullName);

                        table.Rows.Add(dataRow);
                        contador++;
                        _contract = null;

                        if (contador == 100)
                        {
                            totalContratos += contador;

                            Console.WriteLine($"Aguarde...\n\nTotal Arnazenado  {totalContratos} \n");
                            Cnn.FileStores(table, _tableBook);
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

                    Cnn.FileStores(table, _tableBook);
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
            table.Columns.Add("TypeContract", typeof(char));
            table.Columns.Add("NumberContract", typeof(string));
            table.Columns.Add("EncryptedFile", typeof(byte[]));

            return table;
        }
    }
    
}
