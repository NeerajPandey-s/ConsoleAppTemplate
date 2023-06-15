using ConsoleApp.Common.ServiceInstallers.Attributes;
using ConsoleApp.Repository.Repository.Contracts;
using ConsoleApp.Repository.Setup.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Repository.Repository
{
    [ScopedService]
    public class Repository: IRepository
    {
        private IDbProvider _dbProvider;
        public Repository(IDbProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        public async Task<DateTime> CheckDbConnectionAsync()
        {
            return await _dbProvider.ExecuteScalarAsync<DateTime>("select getdate()", commandType: System.Data.CommandType.Text);
        }
    }
}
