using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;
using MySqlConnector;

namespace BancosApi.Infrastructure.Database
{
    public class DbConnection
    {
        private readonly IConfiguration _configuration;
        private readonly string currentDirectory = Path.GetFullPath("../BancosApi.Infrastructure/Database");
        private readonly string databaseFileName = "db.sqlite";

        public DbConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MySqlConnection GetMySqlConnection()
        {
            var connectionString = _configuration.GetConnectionString("MySql");
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
