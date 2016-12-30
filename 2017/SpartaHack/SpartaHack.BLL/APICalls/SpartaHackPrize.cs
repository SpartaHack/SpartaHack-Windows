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
        public async Task<List<Prize>> getPrizes()
        {
            PrizeList prizeList = new PrizeList();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, APIConstants.Prizes);
           
            var response = await client.SendAsync(message);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                prizeList = JsonConvert.DeserializeObject<PrizeList>(jsonString);
                
            }
            return prizeList.prizes;
        }
    }
}