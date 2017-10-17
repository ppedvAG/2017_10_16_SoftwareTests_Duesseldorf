using Shouldly;
using System.Collections.Generic;
using WebApi.Dtos;
using Xunit;

namespace WebApi.Tests.Dtos
{
    public class DonutDtoTests
    {
        [Fact]
        public void Can_create_instance_with_default_values()
        {
            var dto = new DonutDto();
            dto.ShouldNotBeNull();

            dto.Id.ShouldBe(default(int));
            dto.Name.ShouldBeNull();
            dto.Toppings.ShouldBeNull();
        }
    }
}
