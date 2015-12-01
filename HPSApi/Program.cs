using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HPSApi
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://hps-dev-prescreen.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var applicant = new { FullName = "Justin Patterson", Email = "justinpatterson@gmail.com", PhoneNumber = "817.307.6341" };
                client.DefaultRequestHeaders.Add("X-HPS", "apply");
                client.PostAsJsonAsync("api/v1/applicants", applicant).Wait();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://hps-dev-prescreen.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("X-HPS", "apply");
                var result = client.GetStringAsync(@"api/v1/applicants/justinpatterson@gmail.com").Result;

                Console.WriteLine(result);
            }
        }
    }    
}
