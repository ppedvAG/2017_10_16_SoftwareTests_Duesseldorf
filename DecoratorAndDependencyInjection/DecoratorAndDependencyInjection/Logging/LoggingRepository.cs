using System.Collections.Generic;
using DecoratorAndDependencyInjection.Core;
using System.Linq;

namespace DecoratorAndDependencyInjection.Logging
{
    internal class LoggingRepository : RepositoryDecorator
    {
        private readonly ILogger logger;
        private readonly IDateTimeService dateTime;

        public LoggingRepository(
            IRepository repository, 
            ILogger logger, 
            IDateTimeService dateTimeService) 
            : base(repository)
        {
            this.logger = logger;
            dateTime = dateTimeService;
        }

        public override IEnumerable<string> GetAllCustomers()
        {
            logger.Log($"{dateTime.Now.ToString("HH:mm:ss.fff")} | Customers werden geladen.");
            var customers = base.GetAllCustomers();
            logger.Log($"{dateTime.Now.ToString("HH:mm:ss.fff")} | {customers.Count()} Customers fertig geladen.");
            return customers;
        }
    }
}
