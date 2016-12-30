using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaHack.BLL.Models
{  
    public class Prize
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Sponsor sponsor { get; set; }
    }

    public class PrizeList
    {
        public List<Prize> prizes { get; set; }
    }
}
