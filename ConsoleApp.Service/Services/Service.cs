using ConsoleApp.Common.ServiceInstallers.Attributes;
using ConsoleApp.Repository.Repository.Contracts;
using ConsoleApp.Service.Services.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace ConsoleApp.Service.Services
{
    [ScopedService]
    public class Service : IService
    {
        private readonly ILogger<Service> _logger;
        private readonly IRepository _repo;

        public Service(ILogger<Service> logger,
            IRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<DateTime> CheckHealthAsync()
        {
            _logger.LogDebug("Health Check");
            return await _repo.CheckDbConnectionAsync();
        }
    }
}
