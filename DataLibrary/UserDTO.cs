using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    [Serializable]
    public class UserDTO
    {
        public int      UserId { get; set; }
        public string   UserName { get; set; }
        public string   Pass { get; set; }
        public DateTime SignUpDate { get; set; }
        public string   Name { get; set; }
        public string   LastName { get; set; }
        public int      Dni { get; set; }
        public string   Region { get; set; }
    }
}
