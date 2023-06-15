using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp.Startup.Services.Contracts
{
    internal interface IInstaller
    {
        internal void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}
