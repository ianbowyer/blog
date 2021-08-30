using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Bowyer.Blog.TcpReader.Services.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Bowyer.Blog.TcpReader.Database;
using Bowyer.Blog.TcpReader.Database.Services;
using Bowyer.Blog.TcpReader.Services.Service;
using Microsoft.EntityFrameworkCore;

namespace Bowyer.Blog.TcpReader.Services
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public IHostBuilder CreateHostBuilder(string[] args)
        {
            // Get Configuration
            var environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            if (string.IsNullOrEmpty(environmentName))
            {
                environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            }

            var configurationBuilder = new ConfigurationBuilder();
            GetConfiguration(environmentName, configurationBuilder);
            Configuration = configurationBuilder.Build();

            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    GetConfiguration(environmentName, configApp);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    // Configuration
                    services.AddOptions<ListenerSettings>();
                    services.Configure<ListenerSettings>(Configuration.GetSection("ListenerSettings"));
                    services.Configure<ListenerSettings>(options => Configuration.GetSection("listenerSettings").Bind(options));

                    // Hosted service
                    services.AddHostedService<IngestionHostedService>();

                    // Database
                    services.AddDbContext<TelemetryDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TelemetryDatabase")));
                    services.BuildServiceProvider().GetService<TelemetryDbContext>().Database.EnsureCreated();

                    // Services
                    services.AddScoped<IProcessPacketService, ProcessPacketService>();
                    services.AddScoped<IIngestionService, IngestionService>();
                    services.AddScoped<ITelemetryService, TelemetryService>();

                    // Logging
                    var logger = services.BuildServiceProvider().GetService<ILoggerFactory>().CreateLogger(GetType());
                    logger.LogInformation("LogInformation is enabled");
                    logger.LogDebug("LogDebug is enabled");
                    logger.LogError("LogError is enabled");
                    logger.LogCritical("LogCritical is enabled");
                    logger.LogTrace("LogTrace is enabled");
                    logger.LogWarning("LogWarning is enabled");
                });
        }

        private static void GetConfiguration(string environmentName, IConfigurationBuilder configApp)
        {
            configApp
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)

                .AddJsonFile($"appsettings.{environmentName?.ToUpper(CultureInfo.InvariantCulture)}.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}