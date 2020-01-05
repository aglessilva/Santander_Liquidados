using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorToByte.DTO
{
    public class FileSafe
    {
        public int Id { get; set; }
        public string NameContract { get; set; }
        public string T18 { get; set; }
        public string T20 { get; set; }
        public string T25 { get; set; }
        public string DocumentCpf { get; set; }
        public byte[] FileEncryption { get; set; }
    }
}
