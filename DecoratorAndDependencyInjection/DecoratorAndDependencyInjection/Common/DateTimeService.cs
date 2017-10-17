using System;
using DecoratorAndDependencyInjection.Core;

namespace DecoratorAndDependencyInjection.Common
{
    internal class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
