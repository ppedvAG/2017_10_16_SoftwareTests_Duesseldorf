using DecoratorAndDependencyInjection.Controllers;
using DecoratorAndDependencyInjection.Core;
using FakeItEasy;
using Moq;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DecoratorAndDependencyInjection.Tests.Controllers
{
    public class CustomerControllerTests
    {
        [Fact]
        public void Contructor_repository_is_null_should_throw_ArgumentNullExcption()
            => Should.Throw<ArgumentNullException>(() => new CustomerController(null));
        [Fact]
        public void CanCreateInstance() => new CustomerController(new TestRepository()).ShouldNotBeNull();
        [Fact]
        public void GetAll_should_return_DTOs()
        {
            var repository = new TestRepository();
            var controller = new CustomerController(repository);

            var customers = controller.GetAll().ToList();

            repository.WasGetAllCustomersCalled.ShouldBeTrue();

            customers.Count.ShouldBe(3);
            customers.ShouldAllBe(c => c.EndsWith("_DTO"));
            customers[0].ShouldBe("Hans_DTO");
            customers[1].ShouldBe("Peter_DTO");
            customers[2].ShouldBe("Luis_DTO");
        }
        [Fact]
        public void GetAll_should_return_DTOs_Moq()
        {
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(r => 
                r.GetAllCustomers())
                .Returns(new[]
                {
                    "Lisa",
                    "Andrea",
                    "Maria"
                });

            var controller = new CustomerController(repositoryMock.Object);

            var customers = controller.GetAll().ToList();

            repositoryMock.Verify(r => r.GetAllCustomers());

            customers.Count.ShouldBe(3);
            customers.ShouldAllBe(c => c.EndsWith("_DTO"));
            customers[0].ShouldBe("Lisa_DTO");
            customers[1].ShouldBe("Andrea_DTO");
            customers[2].ShouldBe("Maria_DTO");
        }
        [Fact]
        public void GetAll_should_return_DTOs_NSubstitue()
        {
            var repository = Substitute.For<IRepository>();
            repository.GetAllCustomers()
                .Returns(new[]
                {
                    "Lisa",
                    "Andrea",
                    "Maria"
                });

            var controller = new CustomerController(repository);

            var customers = controller.GetAll().ToList();

            repository.Received().GetAllCustomers();

            customers.Count.ShouldBe(3);
            customers.ShouldAllBe(c => c.EndsWith("_DTO"));
            customers[0].ShouldBe("Lisa_DTO");
            customers[1].ShouldBe("Andrea_DTO");
            customers[2].ShouldBe("Maria_DTO");
        }
        [Fact]
        public void GetAll_should_return_DTOs_FakeItEasy()
        {
            var repository = A.Fake<IRepository>();
            A.CallTo(() => repository.GetAllCustomers())
                .Returns(new[]
                {
                    "Lisa",
                    "Andrea",
                    "Maria"
                });

            var controller = new CustomerController(repository);

            var customers = controller.GetAll().ToList();

            A.CallTo(() => repository.GetAllCustomers()).MustHaveHappened();

            customers.Count.ShouldBe(3);
            customers.ShouldAllBe(c => c.EndsWith("_DTO"));
            customers[0].ShouldBe("Lisa_DTO");
            customers[1].ShouldBe("Andrea_DTO");
            customers[2].ShouldBe("Maria_DTO");
        }

        private class TestRepository : IRepository
        {
            public bool WasGetAllCustomersCalled { get; private set; }
            public IEnumerable<string> GetAllCustomers()
            {
                WasGetAllCustomersCalled = true;
                return new[]
                {
                    "Hans",
                    "Peter",
                    "Luis"
                };
            }
        }
    }
}
