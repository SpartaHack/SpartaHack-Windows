using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaHack.BLL.Models
{
    public class Application
    {
        public int birth_day { get; set; }
        public int birth_month { get; set; }
        public int birth_year { get; set; }
        public string education { get; set; }
        public string university { get; set; }
        public string other_university { get; set; }
        public string travel_origin { get; set; }
        public string graduation_season { get; set; }
        public int graduation_year { get; set; }
        public List<string> major { get; set; }
        public int hackathons { get; set; }
        public string github { get; set; }
        public string linkedin { get; set; }
        public string website { get; set; }
        public string devpost { get; set; }
        public string other_link { get; set; }
        public string statement { get; set; }
    }
}
