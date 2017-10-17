using System;

namespace DecoratorAndDependencyInjection.Core
{
    internal interface IDateTimeService
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
