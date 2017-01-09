using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    [Serializable]
    public class BookDTO
    {
        public int      BookId { get; set; }
        public string   Title { get; set; }
        public string   Author { get; set; }
        public string   SectionName { get; set; }
        public int      copies { get; set; }
        public int      Ibsn { get; set; }
    }
}
