using Core.Models;
using Shouldly;
using Xunit;

namespace Core.Tests.Models
{
    public class EntityTests
    {
        [Fact]
        public void Can_create_instance_with_default_vaules()
        {
            var entity = new EmptyEntity();
            entity.Id.ShouldBe(default(int));
            entity.Name.ShouldBeNull();
        }

        private class EmptyEntity : Entity
        { /* should be empty */ }
    }
}
