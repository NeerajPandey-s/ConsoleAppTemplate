using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.Service.Setup.ServiceInstallers.Configuration;
using ConsoleApp.Common.ServiceInstallers.Extentions;
using ConsoleApp.Service.Setup.ServiceInstallers.Contracts;
using System.Reflection;
using System.Linq;
using System;

namespace ConsoleApp.Service.Setup.ServiceInstallers
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection SetupServicesLayer(this IServiceCollection services, ServiceConfig serviceOptions)
        {
            ResolveServiceInstallers(services, serviceOptions);
            services.RegisterApplicationServices(Assembly.GetExecutingAssembly());

            return services;
        }

        private static void ResolveServiceInstallers(IServiceCollection services, ServiceConfig serviceOptions)
        {
            var assemblyServices = typeof(ServiceCollectionExtentions).Assembly
            .DefinedTypes.Where(
                x => typeof(IServiceInstaller).IsAssignableFrom(x)
                    && !x.IsInterface
                    && !x.IsAbstract)
            .Select(Activator.CreateInstance).Cast<IServiceInstaller>().ToList();

            assemblyServices.ForEach(x => x.ConfigureServices(services, serviceOptions));
        }
    }
}
