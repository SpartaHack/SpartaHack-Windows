using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaHack.BLL.Models
{
    public class Ticket
    {
        public string channel { get; set; } = "#testsupporttickets";
        public string username { get; set; }
        public string text { get; set; }
    }
}
