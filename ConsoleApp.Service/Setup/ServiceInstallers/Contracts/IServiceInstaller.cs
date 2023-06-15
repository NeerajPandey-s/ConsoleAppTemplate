using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.Service.Setup.ServiceInstallers.Configuration;

namespace ConsoleApp.Service.Setup.ServiceInstallers.Contracts
{
    internal interface IServiceInstaller
    {
        internal void ConfigureServices(IServiceCollection services, ServiceConfig configuration);
    }
}