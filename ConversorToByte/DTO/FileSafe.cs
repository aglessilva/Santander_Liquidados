using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorToByte.DTO
{
    public class FileSafe
    {
        public string PersonName { get; set; }
        public string PersonDocument { get; set; }
        public string T16 { get; set; }
        public string T18 { get; set; }
        public string T20 { get; set; }
        public string T25 { get; set; }
        public string T34 { get; set; }
        public byte[] EncryptedFile { get; internal set; }
    }
}
