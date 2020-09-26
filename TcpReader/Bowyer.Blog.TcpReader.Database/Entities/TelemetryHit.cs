using System.Collections.Generic;
using System.Text;

namespace Bowyer.Blog.TcpReader.Database.Entities
{
    public class TelemetryHit : TelemetryBase
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}