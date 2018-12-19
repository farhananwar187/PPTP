using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PPTPService
{

    public class ServiceClient
    {
        static HttpClient client;

       public ServiceClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/PptpAPI/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
