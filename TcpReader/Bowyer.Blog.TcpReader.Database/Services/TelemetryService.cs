using System.Threading.Tasks;
using Bowyer.Blog.TcpReader.Database.Entities;
using Bowyer.Blog.TcpReader.Dto;

namespace Bowyer.Blog.TcpReader.Database.Services
{
    public class TelemetryService: ITelemetryService
    {
        private readonly TelemetryDbContext _dbContext;

        public TelemetryService(TelemetryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(TelemetryPacket telemetryPacket)
        {
            await _dbContext.TelemetryHit.AddAsync(new TelemetryHit()
            {
                Latitude = telemetryPacket.Latitude,
                Longitude = telemetryPacket.Longitude
            });
            await _dbContext.SaveChangesAsync();
        }
    }

    public interface ITelemetryService
    {
        Task Add(TelemetryPacket telemetryPacket);
    }
}