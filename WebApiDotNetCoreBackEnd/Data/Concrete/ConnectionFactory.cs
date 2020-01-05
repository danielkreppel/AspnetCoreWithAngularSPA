using System;
using System.Collections.Generic;

using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Data.Contract;
using Microsoft.Extensions.Configuration;

namespace Data.Concrete
{
    public class ConnectionFactory : IConnectionFactory
    {
        private IConfiguration configuration;

        public ConnectionFactory(IConfiguration config)
        {
            configuration = config;
        }
        public IDbConnection GetConnection()
        {
            string connectionString = configuration.GetConnectionString("DBConn");
            var conn = new SqlConnection(connectionString);
            conn.ConnectionString = connectionString;
            return conn;
        }
    }
}
