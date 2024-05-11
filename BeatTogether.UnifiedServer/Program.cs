using BeatTogether.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using BeatTogether.DedicatedServer.Instancing.Extensions;
using BeatTogether.MasterServer.Api.HttpControllers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BeatTogether.Status.Api;
using BeatTogether.Status.Api.Controllers;

namespace BeatTogether.UnifiedServer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateUnifiedServer(args).Build().Run();
        }

        public static IHostBuilder CreateUnifiedServer(string[] args) =>
           Host.CreateDefaultBuilder(args).ConfigureAPIServices().UseStatusServer().UseDedicatedServerInstancing().UseMasterServerApi();

        public static IHostBuilder ConfigureAPIServices(this IHostBuilder hostBuilder) =>
            hostBuilder.ConfigureServices(services => services.AddControllers()
                .AddApplicationPart(Assembly.GetAssembly(typeof(QuickplayController)))
                .AddApplicationPart(Assembly.GetAssembly(typeof(StatusController)))
                .AddApplicationPart(Assembly.GetAssembly(typeof(GetMultiplayerInstanceController)))
                .AddControllersAsServices()
        );
    }
}
