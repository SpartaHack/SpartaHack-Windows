using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SpartaHack.BLL.Models;
using SpartaHack.BLL.Constants;
using Newtonsoft.Json;

namespace SpartaHack.BLL.APICalls
{
    public class SpartaHackMentor
    {

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
