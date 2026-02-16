using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Infrastucture.Interfaces;

namespace WebApi.Infrastucture.Repositories
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string? _connectionString;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection");
        }

        public DbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
