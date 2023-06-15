using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Repository.Repository.Contracts
{
    public interface IRepository
    {
        Task<DateTime> CheckDbConnectionAsync();
    }
}
