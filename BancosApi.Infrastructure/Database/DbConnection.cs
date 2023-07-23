using Microsoft.Extensions.Configuration;
using MySqlConnector;
using BancosApi.Domain.Base.Adapters;

namespace BancosApi.Infrastructure.Database
{
    public class DbConnection : ISqlDatabaseAdapter<MySqlConnection>
    {
        private readonly IConfiguration _configuration;
        public DbConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MySqlConnection GetConnection()
        {
            var connectionString = _configuration.GetConnectionString("MySql");
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
