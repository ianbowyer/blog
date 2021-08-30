using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Bowyer.Blog.TcpReader.Services.Configuration;
using Bowyer.Blog.TcpReader.Services.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bowyer.Blog.TcpReader.Services
{
    public class IngestionService : IDisposable, IIngestionService
    {
        // TBC
        private readonly IServiceProvider _serviceProvider;

        private readonly IProcessPacketService _processPacketService;

        private readonly TcpListener _server;

        private bool _isDisposed;
        private readonly ILogger _logger;
        private readonly ListenerSettings _listenerSettings;

        public IngestionService(
            IOptions<ListenerSettings> listenerSettings,
            ILoggerFactory loggerFactory,
            IProcessPacketService processPacketService,
            IServiceProvider serviceProvider
            )
        {
            _processPacketService = processPacketService;
            _serviceProvider = serviceProvider;
            _logger = loggerFactory.CreateLogger(GetType());

            _listenerSettings = listenerSettings.Value;
            _server = new TcpListener(IPAddress.Any, _listenerSettings.Port);
            _server.Start();
        }

        public void Listen(in CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    StartServer();
                }
            }
            catch (SocketException e)
            {
                _logger.LogError(LogEventIds.ListeningError, e, "Listen caught an exception");
            }
            finally
            {
                _server.Stop();
            }
        }

        private void StartServer()
        {
            _logger.LogInformation(LogEventIds.IngestionServiceStarted, "Ingestion Service started");
            var client = _server.AcceptTcpClient();
            _logger.LogTrace(LogEventIds.TcpClientConnected, "Connected!");

            // Origional code
            //_processPacketService.ProcessPacket(client);
            //CallProcessPacketService(client);
            //_ = CallProcessPacketService(client);
        }

        private async Task CallProcessPacketService(TcpClient client)
        {
            Console.WriteLine("Creating Scope");
            using (var scope = _serviceProvider.CreateScope())
            {
                var processPacketService = scope.ServiceProvider.GetRequiredService<IProcessPacketService>();
                await processPacketService.ProcessPacket(client);
            }
        }

        /// <summary>
        /// Dispose the object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _server.Stop();
                }

                _isDisposed = true;
            }
        }
    }

    public interface IIngestionService
    {
        void Listen(in CancellationToken cancellationToken);
    }
}