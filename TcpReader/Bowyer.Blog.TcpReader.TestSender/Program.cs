using System;
using System.Security.Cryptography.X509Certificates;

namespace Bowyer.Blog.TcpReader.TestSender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private class TelemetryPacket
        {
            public string DeviceNumber { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }
    }
}