using DecoratorAndDependencyInjection.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DecoratorAndDependencyInjection.Controllers
{
    internal class CustomerController
    {
        private readonly IRepository repository;

        public CustomerController(IRepository repository) 
            => this.repository = repository ?? throw new ArgumentNullException(nameof(repository));

        // GET api/customers
        public IEnumerable<string> GetAll() => repository.GetAllCustomers().Select(c => $"{c}_DTO");
    }
}
