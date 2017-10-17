using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Data.Tests.Integration
{
    internal class DbHelper
    {
        private readonly string server;
        private readonly string authentication;
        public string ConnectionString => $"{server};{authentication};database=master";

        public DbHelper(string serverName, string authentication)
        {
            server = serverName;
            this.authentication = authentication;
        }

        public async Task<bool> Exists(string dbName)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
SELECT Count(*)
    FROM master.dbo.sysdatabases 
    WHERE name = '{dbName}'";

                    var count = (int)(await command.ExecuteScalarAsync());
                    return count > 0;
                }
            }
        }

        public async Task CreateDbAsync(string dbName)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
use Master;
Create Database {dbName}
use {dbName};";

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteDbAsync(string dbName)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
use Master;
Drop Database {dbName}";
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task CreateDonutsTable()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
CREATE TABLE Donuts
(
    [Id][int] NOT NULL Primary Key,
    [Name] [nvarchar] (50) NOT NULL
)";
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task CreateToppingsTable()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
CREATE TABLE Toppings
(
    [Id][int] NOT NULL Primary Key,
    [Name] [nvarchar] (50) NOT NULL,
    Color nvarchar (50) NOT NULL,
    [DonutId] [int] NOT NULL Foreign Key references Donuts(Id)
)";
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
