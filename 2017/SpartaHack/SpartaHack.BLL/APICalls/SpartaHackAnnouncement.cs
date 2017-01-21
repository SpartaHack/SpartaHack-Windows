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
    public class SpartaHackAnnouncement
    {
        public List<Announcement> getAnnouncementLocal()
        {
            List<Announcement> data;
            using (var db = new SpartaHackDataStore())
            {
                data = db.AnnouncementItems.ToList();
            }
            return data;
        }
        public async Task<List<Announcement>> getAnnouncement()
        {
            List<Announcement> Announcement = null;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, APIConstants.Announcements);
            message.Headers.Authorization = new AuthenticationHeaderValue("Token", $"token={APIConstants.Token}");
            var response = await client.SendAsync(message);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                Announcement = JsonConvert.DeserializeObject<List<Announcement>>(jsonString);
                using (var db = new SpartaHackDataStore())
                {
                    db.AnnouncementItems.RemoveRange(db.AnnouncementItems);
                    db.SaveChanges();
                    db.AnnouncementItems.AddRange(Announcement);
                    db.SaveChanges();
                }
            }
            return Announcement;

        }

        public List<HeaderGroup<Announcement>> groupAnnouncement(List<Announcement> Announcement)
        {
            var query = from a in Announcement
                        orderby DateTime.Parse(a.updated_at) ascending
                        group a by a.pinned into grouped
                        select new HeaderGroup<Announcement>(grouped)
                        {
                            Header = grouped.Key == 0 ? "Announcements" : "Pinned"
                        };
            return query.ToList();
        }
        public List<HeaderGroup<Announcement>> getLocalAnnouncementGrouped()
        {
            List<Announcement> Announcement = getAnnouncementLocal();
            try
            {
                return groupAnnouncement(Announcement);
            }
            catch
            {
                return new List<HeaderGroup<Announcement>>();
            }
        }

        public async Task<List<HeaderGroup<Announcement>>> getAnnouncementGrouped()
        {
            List<Announcement> Announcement = await getAnnouncement();
            try
            {
                return groupAnnouncement(Announcement);
            }
            catch
            {
                return new List<HeaderGroup<Announcement>>();
            }
        }
    }
}
