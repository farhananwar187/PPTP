using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Net.Http.Formatting;

namespace PPTPService
{

    public class ServiceClient
    {
        public HttpClient client;

       public ServiceClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/PptpAPI/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
       public  async Task<Uri> AddServerAsync(server serv)
        {
            var json = new JavaScriptSerializer().Serialize(serv);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            HttpResponseMessage response = await client.PostAsJsonAsync(
                "server/PostServer", byteContent);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }
        public  async Task<server> GetServerAsync(string serverIP)
        {

            server user = null;
            HttpResponseMessage response = await client.GetAsync("server/GetServer");
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<server>();
            }
            return user;
        }
        public async Task<User> GetUserAsync(string userId, string userPassword)
        {

            User user = null;
            HttpResponseMessage response = await client.GetAsync("user/GetUser");
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }
            return user;
        }
    }
}
