using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
