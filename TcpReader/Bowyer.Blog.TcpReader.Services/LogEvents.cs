using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Bowyer.Blog.TcpReader.Services
{
    public class LogEventIds
    {
        public const int ListeningError = 1000;
        public const int ServiceStart = 1001;
        public const int ServiceEnd = 1002;
        public const int IngestionServiceStarted = 1003;
        public const int TcpClientConnected = 1004;
        public const int ReplyNack = 1005;
        public const int ReplyAck = 1006;
        public const int DeviceConnected = 1007;
        public const int DeviceDenied = 1008;
        public const int PacketReceived = 1009;
    }
}