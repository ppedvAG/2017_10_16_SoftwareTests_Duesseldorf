using System.Collections.Generic;

namespace Core.Models
{
    public class Donut : Entity
    {
        public ICollection<Topping> Toppings { get; set; } = new List<Topping>();
    }
}
