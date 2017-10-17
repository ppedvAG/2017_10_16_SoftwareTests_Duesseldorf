using System.Collections.Generic;

namespace WebApi.Dtos
{
    internal class DonutDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ToppingDto> Toppings { get; set; }
    }
}