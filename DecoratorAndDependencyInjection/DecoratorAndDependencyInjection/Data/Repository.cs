using DecoratorAndDependencyInjection.Core;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DecoratorAndDependencyInjection.Data
{
    internal class Repository : IRepository
    {
        public IEnumerable<string> GetAllCustomers()
        {
            var connectionString = "server=.;database=NORTHWND;integrated security=true";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "Select ContactName from Customers";
                    command.CommandType = System.Data.CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        var customers = new List<string>();

                        while (reader.Read())
                            customers.Add(reader["ContactName"] as string);

                        return customers;
                    }
                }
            }
        }
    }
}
