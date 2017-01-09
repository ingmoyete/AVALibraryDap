using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    [Serializable]
    public class CopyDTO
    {
        public int CopyId { get; set; }
        public int Ibsn { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int SectionId { get; set; }
    }
}
