using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using ConsoleApp.Startup.Services.Configuration;
using Microsoft.Extensions.Options;
using ConsoleApp.Service.Services.Contracts;

namespace ConsoleApp
{
    public class Application
    {
        private readonly ILogger<Application> _logger;
        private readonly AppConfig _appConfig;
        private readonly IService _service;

        public Application(ILogger<Application> logger,
            IOptions<AppConfig> appConfig,
            IService service)
        {
            _logger = logger;
            _appConfig = appConfig.Value;
            _service = service;
        }

        public async Task RunAsync(string[] args)
        {
            try
            {
                var dt = await _service.CheckHealthAsync();
                _logger.LogInformation($"db datetime is: {dt}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}