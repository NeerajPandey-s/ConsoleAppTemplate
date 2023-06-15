using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ConsoleApp.Startup.Services.Configuration;

namespace ConsoleApp.Startup
{
    public static class ServiceRegistry
    {
        public static void RegisterServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<AppConfig>(configuration);
            serviceCollection.AddScoped<Application>();
        }
    }
}
