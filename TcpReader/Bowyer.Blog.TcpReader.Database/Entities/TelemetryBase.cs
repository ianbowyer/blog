using System;

namespace Bowyer.Blog.TcpReader.Database.Entities
{
    /// <summary>
    /// The Telemetry Base
    /// </summary>
    public abstract class TelemetryBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        public DateTime Created { get; set; }
    }
}