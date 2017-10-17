using Shouldly;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Data.Tests.Integration
{
    public class ToppingRepositoryTests
    {
        private readonly DbHelper dbHelper;

        public ToppingRepositoryTests() => dbHelper = new DbHelper("server=.", "integrated security=true");

        [Fact]
        public async Task GetAll_on_empty_table_returns_empty_list_of_toppings()
        {
            var dbName = nameof(GetAll_on_empty_table_returns_empty_list_of_toppings);
            if (await dbHelper.Exists(dbName))
                await dbHelper.DeleteDbAsync(dbName);
            await dbHelper.CreateDbAsync(dbName);
            await dbHelper.CreateDonutsTable();
            await dbHelper.CreateToppingsTable();

            var repository = new ToppingRepository(dbHelper.ConnectionString);

            var toppings = await repository.GetAll();

            toppings.ShouldBeEmpty();

            await dbHelper.DeleteDbAsync(dbName);
        }

        [Fact]
        public async Task GetAll__returns_all_toppings_in_table()
        {
            var dbName = nameof(GetAll__returns_all_toppings_in_table);
            if (await dbHelper.Exists(dbName))
                await dbHelper.DeleteDbAsync(dbName);
            await dbHelper.CreateDbAsync(dbName);
            await dbHelper.CreateDonutsTable();
            await dbHelper.CreateToppingsTable();


            using (var connection = new SqlConnection(dbHelper.ConnectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
Insert Into Donuts (Name) Values ('testDonut')
Insert Into Toppings (Name, Color, DonutId) Values ('T1', 'C1', (Select d.Id From Donuts d Where d.Name = 'testDonut'))
Insert Into Toppings (Name, Color, DonutId) Values ('T2', 'C2', (Select d.Id From Donuts d Where d.Name = 'testDonut'))
Insert Into Toppings (Name, Color, DonutId) Values ('T3', 'C3', (Select d.Id From Donuts d Where d.Name = 'testDonut'))
Insert Into Toppings (Name, Color, DonutId) Values ('T4', 'C4', (Select d.Id From Donuts d Where d.Name = 'testDonut'))
";
                    await command.ExecuteNonQueryAsync();
                }

            }

            var repository = new ToppingRepository(dbHelper.ConnectionString);

            var toppings = await repository.GetAll();

            toppings.Count().ShouldBe(4);
            toppings.ShouldContain(t => t.Name == "T1");
            toppings.ShouldContain(t => t.Name == "T2");
            toppings.ShouldContain(t => t.Name == "T3");
            toppings.ShouldContain(t => t.Name == "T4");

            await dbHelper.DeleteDbAsync(dbName);
        }
    }
}
