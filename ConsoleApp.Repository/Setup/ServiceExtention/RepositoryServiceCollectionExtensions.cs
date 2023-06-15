using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.Common.ServiceInstallers.Extentions;
using ConsoleApp.Repository.Setup.Provider;
using ConsoleApp.Repository.Setup.Contract;
using ConsoleApp.Repository.Setup.ServiceExtention.Configuration;
using System.Reflection;

namespace ConsoleApp.Repository.Setup.ServiceExtention
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, DapperOptions dapperOptions) => ResolveDbProviders(services, dapperOptions);

        private static IServiceCollection ResolveDbProviders(IServiceCollection services, DapperOptions dapperOptions)
        {
            services.RegisterApplicationServices(Assembly.GetExecutingAssembly());
            services.Add(ServiceDescriptor.Describe(typeof(IDbProvider), (provider) =>
            {
                return new DbProvider(dapperOptions.ConnectionString);
            }, ServiceLifetime.Singleton));

            return services;
        }
    }
}

