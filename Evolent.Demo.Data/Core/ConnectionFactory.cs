using Evolent.Demo.Data.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Demo.Data.Core
{
    public class ConnectionFactory : IConnectionFactory
    {

        private readonly DbProviderFactory providerFactory;
        public string connectionString;
        public ConnectionFactory(string _connectionString)
        {
            providerFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            connectionString = _connectionString;
        }

        public IDbConnection GetConnection()
        {

            var conn = providerFactory.CreateConnection();
            conn.ConnectionString = connectionString;
            return conn;
        }
    }
}
