using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AppService.Class;
using AppService.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplicationForMySQLdb.Data;
using WebApplicationForMySQLdb.Models;

namespace WebApplicationForMySQLdb
{
    public class Program
    {
        private static IConfiguration _configuration { get; set; }
        private static AppServices _appServices = new AppServices();

        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

            var Config = _configuration["UserRoles:Roles"];
            var myQ = _appServices.ConfigToQueue(Config);
            var newQ = _appServices.GetRoles(myQ);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    DbInitializer.RolesNames = newQ;
                    DbInitializer.InitializeAsync(context, services).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
