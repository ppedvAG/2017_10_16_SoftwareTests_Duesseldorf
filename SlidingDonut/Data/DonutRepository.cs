using Core.Models;
using Core.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class DonutRepository : IRepository<Donut>
    {
        private readonly ToppingRepository toppingRepository;
        private readonly string connectionString;

        public DonutRepository(ToppingRepository toppingRepository, string connectionString)
        {
            this.toppingRepository = toppingRepository;
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Donut>> GetAll()
        {
            var toppings = await toppingRepository.GetAll();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
Select Id
    , Name
    from Donuts";

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        var donuts = new List<Donut>();
                        while (await reader.ReadAsync())
                        {
                            var donut = new Donut
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                            };

                            var toppingsForThisDonut = toppings.Where(t => t.DonutId == donut.Id);
                            foreach (var t in toppingsForThisDonut)
                            {
                                t.Donut = donut;
                                donut.Toppings.Add(t);
                            }

                            donuts.Add(donut);
                        }
                        return donuts;
                    }
                }
            }
        }
    }
}
