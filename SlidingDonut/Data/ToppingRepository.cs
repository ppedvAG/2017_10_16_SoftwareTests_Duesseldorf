using System.Collections.Generic;
using Core.Models;
using Core.Repositories;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Data
{
    public class ToppingRepository : IRepository<Topping>
    {
        private readonly string connectionString;

        public ToppingRepository(string connectionString) => this.connectionString = connectionString;

        public async Task<IEnumerable<Topping>> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
Select Id
    , Name
    , Color
    , DonutId
    from Toppings";

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var toppings = new List<Topping>();
                        while (await reader.ReadAsync())
                        {
                            toppings.Add(new Topping
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Color = (string)reader["Color"],
                                DonutId = (int)reader["ToppingsId"]
                            });
                        }
                        return toppings;
                    }
                }
            }
        }
    }
}
