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
    public class SpartaHackMentor
    {

        public async Task<List<TicketCategory>> getTicketCategories()
        {
            List<TicketCategory> categories = null;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, APIConstants.Categories);
            message.Headers.Authorization = new AuthenticationHeaderValue("Token", $"token={APIConstants.Token}");
            var response = await client.SendAsync(message);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<List<TicketCategory>>(jsonString);
            }
            return categories;
        }

        public async Task SubmitTicket(Ticket ticket)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, APIConstants.SlackURL);
            string jsonBodyString = JsonConvert.SerializeObject(ticket);
            message.Content= new StringContent(jsonBodyString, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(message);
        }
    }
}
