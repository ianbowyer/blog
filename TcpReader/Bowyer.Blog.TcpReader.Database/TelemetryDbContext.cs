using System;
using Bowyer.Blog.TcpReader.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bowyer.Blog.TcpReader.Database
{
    public class TelemetryDbContext : DbContext
    {
        public TelemetryDbContext(DbContextOptions<TelemetryDbContext> options)
            : base(options)
        { }

        public DbSet<TelemetryHit> TelemetryHit { get; set; }
    }
}