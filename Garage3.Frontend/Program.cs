using System;
using Garage3.Data;
using Garage3.Data.Seed;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Garage3.Frontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    SeedData.InitAsync(services).Wait();
                }
                catch (Exception e)
                {
                    var logger = services.GetRequiredService <ILogger<Program>>();
                    logger.LogError(e.Message, "Seed Fail");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
