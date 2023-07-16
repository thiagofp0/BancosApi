using Microsoft.Data.Sqlite;
using System.IO;

namespace BancosApi.Infrastructure.Database
{
    public class DbConnection
    {
        private readonly string currentDirectory = Directory.GetCurrentDirectory();
        private readonly string databaseFileName = "db.sqlite";

        public SqliteConnection GetConnection()
        {
            var databasePath = Path.Combine(currentDirectory, databaseFileName);
            var connectionString = $"Data Source={databasePath}";

            var connection = new SqliteConnection(connectionString);
            connection.Open();

            return connection;
        }
    }
}
