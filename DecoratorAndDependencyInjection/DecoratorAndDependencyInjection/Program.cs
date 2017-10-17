using DecoratorAndDependencyInjection.Common;
using DecoratorAndDependencyInjection.Controllers;
using DecoratorAndDependencyInjection.Core;
using DecoratorAndDependencyInjection.Data;
using DecoratorAndDependencyInjection.Logging;
using StructureMap;
using System;

namespace DecoratorAndDependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Unity Container
            // MEF - Managed Extensibility Framework
            // NInject
            // Autofac
            // in .NET Core ServiceCollection
            // StructureMap

            //            var logger = new ConsoleLogger();
            //            var dateTime = new DateTimeService();

            //            IRepository repository = new Repository();
            //#if DEBUG
            //            repository = new LoggingRepository(repository, logger, dateTime);
            //#endif
            //            var controller = new CustomerController(repository);

            var container = new Container(c =>
            {
                c.For<ILogger>().Use<ConsoleLogger>().Singleton();
                c.For<IDateTimeService>().Use<DateTimeService>().Singleton();

                c.For<IRepository>().Use<Repository>();
                c.For<IRepository>().DecorateAllWith<LoggingRepository>();
            });

            var controller = container.GetInstance<CustomerController>();

            // ein Get Request
            var customers = controller.GetAll();
            foreach (var c in customers)
                Console.WriteLine(c);

            Console.ReadKey();
        }
    }
}
