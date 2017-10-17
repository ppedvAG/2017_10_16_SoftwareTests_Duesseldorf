using DecoratorAndDependencyInjection.Core;
using FakeItEasy;
using Shouldly;
using Xunit;

namespace DecoratorAndDependencyInjection.Tests.Core
{
    public class RepositoryDecoratorTests
    {
        [Fact]
        public void CanCreateInstance() => new EmptyRepositoryDecorator(null).ShouldNotBeNull();

        [Fact]
        public void GetAllCustomers_should_call_GetAllCustomers_from_concreteRepository()
        {
            var concreteRepository = A.Fake<IRepository>();
            var decorator = new EmptyRepositoryDecorator(concreteRepository);

            decorator.GetAllCustomers();

            A.CallTo(() => concreteRepository.GetAllCustomers()).MustHaveHappened();
        }

        private class EmptyRepositoryDecorator : RepositoryDecorator
        {
            public EmptyRepositoryDecorator(IRepository repository) : base(repository)
            { }
        }
    }
}
