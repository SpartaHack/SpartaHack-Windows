using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpartaHack.BLL.Models
{  
    public class Prize
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        private Sponsor _sponsor;
        public Sponsor sponsor {
            get { return _sponsor == null ? _sponsor : new Sponsor(); }
            set { _sponsor = value; } }
    }

    public class PrizeList
    {
        public List<Prize> prizes { get; set; }
    }
}
