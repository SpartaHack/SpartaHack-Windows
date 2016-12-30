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
            }
            return sponsors;
        }

        public async Task<List<HeaderGroup<Sponsor>>> getSponsorsGrouped()
        {
            List<Sponsor> sponsors = await getSponsors();
            
            var query = from s in sponsors
                        orderby s.name, s.levelId descending
                        group s by s.level into grouped
                        select new HeaderGroup<Sponsor>(grouped)
                        {
                            Header = grouped.Key,

                        };
            return query.ToList();
        }
    }
}
