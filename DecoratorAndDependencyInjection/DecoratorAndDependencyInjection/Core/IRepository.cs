using System.Collections.Generic;

namespace DecoratorAndDependencyInjection.Core
{
    public interface IRepository
    {
        IEnumerable<string> GetAllCustomers();
    }
}