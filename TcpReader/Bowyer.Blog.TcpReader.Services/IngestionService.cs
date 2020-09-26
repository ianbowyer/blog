using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Bowyer.Blog.TcpReader.Services.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bowyer.Blog.TcpReader.Services
{
    internal class IngestionService : IDisposable, IIngestionService
    {
        private readonly TcpListener _server;
        private bool _isDisposed;
        private ILogger _logger;

        public IngestionService(
            IOptions<ListenerSettings> listenerSettings,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(GetType());
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
            throw new NotImplementedException();
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