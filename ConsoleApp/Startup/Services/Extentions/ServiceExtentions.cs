using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.Startup.Services.Contracts;
using System;
using System.Linq;

namespace ConsoleApp.Startup.Services.Extentions
{
    public static class ServiceExtentions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var middlewares = typeof(ServiceExtentions).Assembly
                        .ExportedTypes.Where(
                            x => typeof(IInstaller).IsAssignableFrom(x)
                                && !x.IsInterface
                                && !x.IsAbstract)
                        .Select(Activator.CreateInstance)
                        .Cast<IInstaller>()
                        .ToList();

            middlewares.ForEach(x => x.ConfigureServices(services, configuration));
        }
    }
}
