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

        public static void setCurrentUser(User user)
        {
            using (var db = new SpartaHackDataStore())
            {
                if (db.CurrentUser.Count() > 0)
                {
                    db.CurrentUser.Remove(db.CurrentUser.ElementAt(0));
                    db.SaveChanges();
                }
                db.CurrentUser.Add(user);
                db.SaveChanges();
            }
        }
        public static User getCurrentUser()
        {
            User current = null;
            try
            {
                using (var db = new SpartaHackDataStore())
                {
                    current = db.CurrentUser.FirstOrDefault();
                }
            }
            catch { }
            
            return current;
        }
        public async Task<User> createUser(User newUser)
        {
            User current= new User();
            try
            {
                var encapsulated = new { user = newUser };
                var jsonBodyString = JsonConvert.SerializeObject(encapsulated);

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, APIConstants.Users);
                message.Headers.Authorization = new AuthenticationHeaderValue("Token", $"token={APIConstants.Token}");
                message.Content = new StringContent(jsonBodyString, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(message);


                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    current = JsonConvert.DeserializeObject<User>(jsonString);
                    setCurrentUser(current);
                }

            }
            catch (Exception e)
            {
                string error = e.Message;
            }
           


            return current;
        }

        public async Task<User> CreateSession(User user)
        {

            User current = null;
            //try
            //{
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.example.v2"));
              
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, APIConstants.Sessions);
              
                message.Headers.Authorization = new AuthenticationHeaderValue("Token", $"token={APIConstants.Token}");

                var messageBody = new { email = user.email, password = user.password };
                string jsonBodyString = JsonConvert.SerializeObject(messageBody);
                message.Content = new StringContent(jsonBodyString, Encoding.UTF8, "application/json");



                var response = await client.SendAsync(message);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    current = JsonConvert.DeserializeObject<User>(jsonString);
                    setCurrentUser(current);
                }
            //}
            //catch (Exception e)
            //{
            //    string message = e.Message;

            //}
            return current;


        }



    }
}
