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
   public class SpartaHackSponsor
    {
        public async Task<List<Sponsor>> getSponsors()
        {
            List<Sponsor> sponsors = new List<Sponsor>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, APIConstants.Sponsors);
            message.Headers.Authorization = new AuthenticationHeaderValue("Token", $"token={APIConstants.Token}");

            var response = await client.SendAsync(message);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                sponsors = JsonConvert.DeserializeObject<List<Sponsor>>(jsonString);
                using (var db = new SpartaHackDataStore())
                {
                    db.Sponsors.RemoveRange(db.Sponsors);
                    db.SaveChanges();
                    db.Sponsors.AddRange(sponsors);
                    db.SaveChanges();
                }
            }
            return sponsors;


        }
        public List<HeaderGroup<Sponsor>> groupSponsors(List<Sponsor> sponsors)
        {
            var query = from s in sponsors
                        orderby s.name, s.levelId descending
                        group s by s.level into grouped
                        select new HeaderGroup<Sponsor>(grouped)
                        {
                            Header = grouped.Key,

                        };
            return query.ToList();
        }
        public List<HeaderGroup<Sponsor>> getLocalSponsorsGrouped()
        {
            List<Sponsor> data;
            using (var db = new SpartaHackDataStore())
            {
                data = db.Sponsors.Where(s=>s.level!="").ToList();
            }
            if (data == null)
                return new List<HeaderGroup<Sponsor>>();
            return groupSponsors(data);
        }

        public async Task<List<HeaderGroup<Sponsor>>> getSponsorsGrouped()
        {
            List<Sponsor> sponsors = await getSponsors();
            return groupSponsors(sponsors);
            
        }
    }
}
