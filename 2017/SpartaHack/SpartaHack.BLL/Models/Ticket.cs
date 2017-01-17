using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaHack.BLL.Models
{
    public class Ticket
    {
        public string channel { get; set; }
        public string username { get; set; }
        public string text { get; set; }
    }

    public class TicketCategory
    {
        public int id { get; set; }
        public string category { get; set; }
        public string channel { get; set; }
    }
}
