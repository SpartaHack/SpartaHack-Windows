using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using SpartaHack.BLL.Constants;
using SpartaHack.BLL.Models;
using System.Net.Http.Headers;

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
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, APIConstants.Schedule);
            message.Headers.Authorization = new AuthenticationHeaderValue("Token", $"token={APIConstants.Token}");
            var response = await client.SendAsync(message);
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
        public async Task<List<HeaderGroup<Schedule>>> getScheduleGrouped()
        {
            List<Schedule> schedule = await getSchedule();
            try
            {
                var query = from s in schedule
                            group s by DateTime.Parse(s.time).Date into grouped
                            select new HeaderGroup<Schedule>(grouped)
                            {
                                Header = grouped.Key.ToString("dddd, dd")
                            };
                return query.ToList();
            }
            catch
            {
                return new List<HeaderGroup<Schedule>>();
            }
        }
    }
}
