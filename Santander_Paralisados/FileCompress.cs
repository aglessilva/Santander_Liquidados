using System;
using System.Collections.Generic;

namespace Santander_Paralisados
{
    public class FileCompress
    {
        public int Id { get; set; }
        public string TypeContract {get; set;}
        public string PersonName {get; set;}
        public string PersonDocument {get; set;}
        public string NumberContract {get; set;}
        public DateTime DateContract {get; set;}
        public DateTime DateInclude {get; set;}
        public byte[] EncryptedFile {get; set;}
    }


    public class ContratosPdf
    {
        public ContratosPdf()
        {
            Tela16 = new List<KeyValuePair<string, string>>();
            Tela18 = new List<KeyValuePair<string, string>>();
            Tela20 = new List<KeyValuePair<string, string>>();
            Tela25 = new List<KeyValuePair<string, string>>();
            Tela34 = new List<KeyValuePair<string, string>>();
        }
        public List<KeyValuePair<string,string>> Tela16 { get; set; }
        public List<KeyValuePair<string,string>> Tela18 { get; set; }
        public List<KeyValuePair<string,string>> Tela20 { get; set; }
        public List<KeyValuePair<string,string>> Tela25 { get; set; }
        public List<KeyValuePair<string,string>> Tela34 { get; set; }
    }
}
