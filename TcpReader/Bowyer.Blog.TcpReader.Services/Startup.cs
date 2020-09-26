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
                .ConfigureLogging((hostContext, logging) =>
                {
                    //logging.ClearProviders();
                    //logging.SetMinimumLevel(defaultLogLevel);
                    //logging.AddNLog();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOptions<ListenerSettings>();
                    services.Configure<ListenerSettings>(Configuration.GetSection("ListenerSettings"));
                    services.AddHostedService<IngestionHostedService>();
                    AddServices(services, Configuration);

                    var logger = services.BuildServiceProvider().GetService<ILoggerFactory>().CreateLogger(GetType());
                    logger.LogInformation("LogInformation is enabled");
                    logger.LogDebug("LogDebug is enabled");
                    logger.LogError("LogError is enabled");
                    logger.LogCritical("LogCritical is enabled");
                    logger.LogTrace("LogTrace is enabled");
                    logger.LogWarning("LogWarning is enabled");
                });
        }

        protected void AddServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<ListenerSettings>(options => configuration.GetSection("listenerSettings").Bind(options));
            services.AddDbContext<TelemetryDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TelemetryDatabase")));
            services.AddScoped<IIngestionService, IngestionService>();
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