using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToByte
{
    class RemoverDuplicados
    {
        static int Main(string[] args)
        {

            KeyValuePair<string, FileInfo> pair ;
            FileInfo fileInfo = null;
            List<KeyValuePair<string, FileInfo>> valuePairs = new List<KeyValuePair<string, FileInfo>>();

            string[] telas = { "16", "34" };

            foreach (string itemTela in telas)
            {
               
                Directory.EnumerateFiles(@"C:\@TombamentoV1_01\duplicados\", $"*{itemTela}.pdf*", SearchOption.AllDirectories).ToList().ForEach(c =>
                {

                    fileInfo = new FileInfo(c);
                    pair = new KeyValuePair<string, FileInfo>(fileInfo.Name.Split('_')[0], fileInfo);
                    valuePairs.Add(pair);
                });

                var duplicado = valuePairs.GroupBy(g => g.Key).Where(w => w.Count() > 1).ToList();

                if(duplicado.Count > 0)
                    Console.WriteLine($"Removendo duplicados da tela {itemTela}");

                valuePairs.Clear();
                duplicado.ForEach(dup =>
                {
                    for (int i = 1; i < dup.Count(); i++)
                    {
                        File.Move(dup.ElementAt(i).Value.FullName, $"{dup.ElementAt(i).Value.FullName.Replace(".pdf", ".dup").Replace(".PDF",".dup")}");
                    }
                });

                fileInfo = null;
                duplicado.Clear();
            }


            Console.WriteLine("\n\n*** Finalizado ***\n\n pressione tecla ESC para fechar");
            Console.ReadKey();
            return 0;
        }
    }
}
