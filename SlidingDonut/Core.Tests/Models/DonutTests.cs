using Core.Models;
using Shouldly;
using Xunit;

namespace Core.Tests.Models
{
    public class DonutTests
    {
        [Fact]
        public void Can_create_instance_with_default_vaules()
        {
            var donut = new Donut();
            donut.ShouldNotBeNull();

            donut.Id.ShouldBe(default(int));
            donut.Name.ShouldBeNull();
            donut.Toppings.ShouldNotBeNull();
            donut.Toppings.ShouldBeEmpty();
        }
    }
}
