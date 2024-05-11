using BeatTogether.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using BeatTogether.DedicatedServer.Instancing.Extensions;


namespace BeatTogether.UnifiedServer
{
    public static class Program
    {
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseDedicatedServerInstancing().UseMasterServerApi();

    }
}
