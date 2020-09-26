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
    }
}