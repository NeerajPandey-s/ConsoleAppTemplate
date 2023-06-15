using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.Repository.Setup.ServiceExtention;
using ConsoleApp.Repository.Setup.ServiceExtention.Configuration;
using ConsoleApp.Service.Setup.ServiceInstallers.Configuration;
using ConsoleApp.Service.Setup.ServiceInstallers.Contracts;

namespace ConsoleApp.Service.Setup.ServiceInstallers
{
    internal class RepositoryInstaller : IServiceInstaller
    {
        void IServiceInstaller.ConfigureServices(IServiceCollection services, ServiceConfig configuration) =>
            services.AddDbContext(new DapperOptions
            {
                ConnectionString = configuration.ConnectionString
            });
    }
}