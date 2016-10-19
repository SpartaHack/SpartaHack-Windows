using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;
using SpartaHack.BLL.Models;
using SpartaHack.BLL.Constants;
namespace SpartaHack.BLL.APICalls
{
    public class SpartaHackUser
    {
        private static User current;
        public static User CurrentUser()
        {
            return current;
        }
        public async Task<User> createUser(User newUser)
        {
            current = null;
            //try
            //{
            var encapsulated = new { user = newUser };
            var jsonBodyString = JsonConvert.SerializeObject(encapsulated);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", $"Token token={APIConstants.Token}");
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, APIConstants.Users);
           message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            message.Headers.Authorization = new AuthenticationHeaderValue("Authorization", $"Token token={APIConstants.Token}");
            message.Content = new StringContent(jsonBodyString, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(message);


            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                current = JsonConvert.DeserializeObject<User>(jsonString);
            }

            //}
            //catch
            //{

            //}
            return current;
        }

        public async Task<User> getUser(User user)
        {
            current = null;
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(APIConstants.Users + user.id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    current = JsonConvert.DeserializeObject<User>(jsonString);
                }
            }
            catch
            {

            }
            return current;

        }

    }
}
