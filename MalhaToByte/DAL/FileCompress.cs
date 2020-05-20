using System;
using System.Collections.Generic;

namespace MalhaToByte.DAL
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


    public class UploadFileContract
    {
        public char TypeContract { get; set; }
        public string TableName { get; set; }
        public int Tela { get; set; }
        public IEnumerable<string> Contracts { get; set; }
    }
}
