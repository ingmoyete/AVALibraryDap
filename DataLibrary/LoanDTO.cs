using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    [Serializable]
    public class LoanDTO
    {
        public int CopyId { get; set; }
        public int LoanId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Dni { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Section { get; set; }
    }
}
