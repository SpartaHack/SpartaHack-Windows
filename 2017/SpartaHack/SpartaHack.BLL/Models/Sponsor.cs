using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaHack.BLL.Models
{
    public class Sponsor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string logo_svg_light { get; set; }
        public string logo_png_light { get; set; }
        public string logo_svg_dark { get; set; }
        public string logo_png_dark { get; set; }
        public string level { get; set; }

        public int levelId
        {
            get
            {
                if (level == "partner")
                    return 1;
                if (level == "trainee")
                    return 2;
                if (level == "warrior")
                    return 3;
                if (level == "commander")
                    return 4;
                if (level == "ledgend")
                    return 5;
                return 0;
            }
        }


        
    }
}
