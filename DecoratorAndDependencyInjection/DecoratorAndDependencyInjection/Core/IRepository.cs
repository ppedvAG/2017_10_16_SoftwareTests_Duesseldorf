using System.Collections.Generic;

namespace DecoratorAndDependencyInjection.Core
{
    internal interface IRepository
    {
        IEnumerable<string> GetAllCustomers();
    }
}