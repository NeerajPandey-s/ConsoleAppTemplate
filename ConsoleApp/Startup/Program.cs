using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ConsoleApp.Startup
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (Startup.ServiceProvider as IDisposable)
            {
                var app = Startup.ServiceProvider.GetRequiredService<Application>();
                await app.RunAsync(args);
            }
        }
    }
}
