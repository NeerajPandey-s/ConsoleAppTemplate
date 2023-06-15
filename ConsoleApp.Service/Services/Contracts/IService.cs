using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Service.Services.Contracts
{
    public interface IService
    {
        Task<DateTime> CheckHealthAsync();
    }
}
