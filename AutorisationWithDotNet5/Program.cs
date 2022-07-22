using IdentityAutorisationWithDotNet5.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace IdentityAutorisationWithDotNet5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // провераяем создана ли база 
            using (var scope = host.Services.CreateScope())
            {
                var servicesProvider = scope.ServiceProvider;
                try
                {
                    var context = servicesProvider.GetRequiredService<AuthDbContext>();
                    DbInitialize.Initialize(context);
                }
                catch (Exception exception)
                {
                    var logger = servicesProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "Error initialization");
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

