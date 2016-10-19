using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaHack.BLL.Models
{
    public class ScheduleResponse
    {
         public List<Schedule> schedule { get; set; }
    }
    public class Schedule
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string time { get; set; }
        public string location { get; set; }
        public string updatedAt { get; set; }

    }
}
