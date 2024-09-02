using Discount.Infrastructure.Extensions;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Discount.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigrateDatabase<Program>();
            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureKestrel(x => x.ListenAnyIP(9002, o => o.Protocols = HttpProtocols.Http2));
                });
    }
}
