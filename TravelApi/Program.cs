using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TravelApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Generate a secret key
            // var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            // var bytes = new byte[256 / 8];
            // rng.GetBytes(bytes);
            // Console.WriteLine(Convert.ToBase64String(bytes));
            CreateWebHostBuilder(args).Build().Run();
        }

        // public static async Task<string> MainAsync()
        // {
        //     using (var httpClient = new HttpClient())
        //     {
        //         httpClient.BaseAddress = new Uri("http://localhost:5000");

        //         var accessToken = await GetAccessToken();

        //         httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        //         var response = await httpClient.GetAsync("/api/Product");

        //         return $"Status Code: {response.StatusCode}\nContent: {await response.Content.ReadAsStringAsync()}";
        //     }
        // }

        // public static async Task<string> GetAccessToken()
        // {
        //     using (var httpClient = new HttpClient())
        //     {
        //         httpClient.BaseAddress = new Uri("http://localhost:5000");

        //         var httpContent = new StringContent("{Email: \"mosalla@gmail.com\", Password: \"123654\"}", Encoding.UTF8, "application/json");

        //         var response = await httpClient.PostAsync("/Token/Generate", httpContent);

        //         return await response.Content.ReadAsStringAsync();
        //     }
        // }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
