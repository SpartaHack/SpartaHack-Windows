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
    public class SpartaHackPrize
    {
        public List<Prize> getPrizesLocal()
        {
            List<Prize> data;
            using (var db = new SpartaHackDataStore())
            {
                data = db.Prizes.Where(p => p.name != "").ToList();
            }
            if (data == null)
                return new List<Prize>();
            return data;
        }

        public async Task<List<Prize>> getPrizes()
        {
            List<Prize> prizeList = new List<Prize>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, APIConstants.Prizes);
            message.Headers.Authorization = new AuthenticationHeaderValue("Token", $"token={APIConstants.Token}");
            
            var response = await client.SendAsync(message);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                prizeList = JsonConvert.DeserializeObject<List<Prize>>(jsonString);
                using (var db = new SpartaHackDataStore())
                {
                    db.Prizes.RemoveRange(db.Prizes);
                    db.SaveChanges();
                    db.Prizes.AddRange(prizeList);
                    db.SaveChanges();
                }
            }
            return prizeList;
        }
    }
}