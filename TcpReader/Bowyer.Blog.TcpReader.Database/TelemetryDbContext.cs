using System;
using Microsoft.EntityFrameworkCore;

namespace Bowyer.Blog.TcpReader.Database
{
    public class TelemetryDbContext : DbContext
    {
        public TelemetryDbContext(DbContextOptions<TelemetryDbContext> options)
            : base(options)
        {
        }
    }
}