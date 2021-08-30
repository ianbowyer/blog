using Microsoft.Extensions.Hosting;

namespace Bowyer.Blog.TcpReader.Services
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            new Startup().CreateHostBuilder(args)
                //.UseWindowsService()
                .Build()
                .Run();
        }
    }
}