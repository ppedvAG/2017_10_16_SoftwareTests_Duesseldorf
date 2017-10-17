using Shouldly;
using WebApi.Dtos;
using Xunit;

namespace WebApi.Tests.Dtos
{
    public class ToppingDtoTests
    {
        [Fact]
        public void Can_create_instance_with_default_values()
        {
            var dto = new ToppingDto();
            dto.ShouldNotBeNull();

            dto.Id.ShouldBe(default(int));
            dto.Name.ShouldBeNull();
            dto.Color.ShouldBeNull();
        }
    }
}
