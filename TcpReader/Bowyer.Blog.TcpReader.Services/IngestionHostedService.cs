using System;
using System.Threading;
using System.Threading.Tasks;
using Bowyer.Blog.TcpReader.Services.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bowyer.Blog.TcpReader.Services
{
    public class IngestionHostedService :  IDisposable, IHostedService
    {
        private readonly IIngestionService _listener;

        private readonly ILogger _logger;

        private readonly ListenerSettings _listenerSettings;

        public IngestionHostedService(
            IIngestionService listener,
            ILoggerFactory logger,
            IOptions<ListenerSettings> listenerSettings)
        {
            if (listenerSettings == null)
            {
                throw new ArgumentNullException(nameof(listenerSettings));
            }

            _listener = listener;
            _logger = logger.CreateLogger(GetType());
            _listenerSettings = listenerSettings.Value;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation(LogEventIds.ServiceStart, $"Starting {_listenerSettings.Port} Ingestion Service ({Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")})");
            await DoWork(cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public  Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation(LogEventIds.ServiceEnd, "Stopping Ingestion");
            return Task.CompletedTask;
        }

        /// <summary>
        /// Does the work.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task.</returns>
        private Task DoWork(CancellationToken cancellationToken)
        {
            _listener.Listen(cancellationToken);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}