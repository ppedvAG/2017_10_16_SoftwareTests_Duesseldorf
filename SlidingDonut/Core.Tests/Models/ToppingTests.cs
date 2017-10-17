using Core.Models;
using Shouldly;
using Xunit;

namespace Core.Tests.Models
{
    public class ToppingTests
    {
        [Fact]
        public void Can_create_instance_with_default_vaules()
        {
            var topping = new Topping();
            topping.ShouldNotBeNull();

            topping.Id.ShouldBe(default(int));
            topping.Name.ShouldBeNull();
            topping.Color.ShouldBeNull();
            topping.DonutId.ShouldBe(default(int));
            topping.Donut.ShouldBeNull();
        }
    }
}
