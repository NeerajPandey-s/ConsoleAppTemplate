using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.Service.Setup.ServiceInstallers;
using ConsoleApp.Service.Setup.ServiceInstallers.Configuration;
using ConsoleApp.Startup.Services.Contracts;

namespace ConsoleApp.Startup.Services
{
    public class ServiceLayerInstaller : IInstaller
    {
        void IInstaller.ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            ResolveServiceLayerDependencies(services, configuration);
            SetupServiceLayerDependencies(services, configuration);
        }

        private static void ResolveServiceLayerDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ServiceConfig>(configuration);
        }

        private static void SetupServiceLayerDependencies(IServiceCollection services, IConfiguration configuration)
        {
            var serviceConfig = configuration.Get<ServiceConfig>();
            services.SetupServicesLayer(serviceConfig);
        }
    }
}
