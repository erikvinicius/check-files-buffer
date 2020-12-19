using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckFilesBuffer.Models
{
    public class Item
    {
        public string Path { get; set; }
        public byte[] Buffer { get; set; }
    }
}
