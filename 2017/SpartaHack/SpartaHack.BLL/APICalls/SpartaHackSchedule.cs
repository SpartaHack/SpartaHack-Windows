using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using SpartaHack.BLL.Constants;
using SpartaHack.BLL.Models;

namespace SpartaHack.BLL.APICalls
{
    public class SpartaHackSchedule
    {
        public List<Schedule> getScheduleLocal()
        {
            List<Schedule> data;
            using (var db = new SpartaHackDataStore())
            {
                data = db.ScheduleItems.ToList();
            }
            return data;
        }
        public async Task<List<Schedule>> getSchedule()
        {
            List<Schedule> schedule = null;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(APIConstants.Schedule);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                schedule = JsonConvert.DeserializeObject<ScheduleResponse>(jsonString).schedule;
                using (var db = new SpartaHackDataStore())
                {
                    db.ScheduleItems.RemoveRange(db.ScheduleItems);
                    db.SaveChanges();
                    db.ScheduleItems.AddRange(schedule);
                    db.SaveChanges();
                }
            }
            return schedule;

        }
    }
}
