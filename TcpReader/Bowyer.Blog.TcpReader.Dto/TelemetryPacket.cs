using System;
using System.Collections.Generic;

namespace Bowyer.Blog.TcpReader.Dto
{
    public class TelemetryPacket
    {
        public TelemetryPacket(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public TelemetryPacket(byte[] packet)
        {
            if (packet.Length != 16)
            {
                throw new ArgumentException("packet expected to be 16 bytes");
            }
            Latitude = BitConverter.ToDouble(packet, 0);
            Longitude = BitConverter.ToDouble(packet, 8);
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public byte[] GenerateBytes()
        {
            var bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(Latitude));
            bytes.AddRange(BitConverter.GetBytes(Longitude));
            return bytes.ToArray();
        }
    }
}