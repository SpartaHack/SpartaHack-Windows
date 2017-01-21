using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaHack.BLL.Models
{
    public class Announcement
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int pinned { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
