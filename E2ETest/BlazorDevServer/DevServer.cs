using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace UnitedSystemsCooperative.Web.E2ETest.BlazorDevServer;

    public class DevServer
    {
        public static IHost BuildWebHost(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(config =>
                {
                    var inMemoryConfiguration = new Dictionary<string, string>
                    {
                        [WebHostDefaults.EnvironmentKey] = "Development",
                        ["Logging:LogLevel:Microsoft"] = "Warning",
                        ["Logging:LogLevel:Microsoft.Hosting.Lifetime"] = "Information",
                    };

                    config.AddInMemoryCollection(inMemoryConfiguration);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStaticWebAssets();
                    webBuilder.UseStartup<Startup>();
                }).Build();
    }
