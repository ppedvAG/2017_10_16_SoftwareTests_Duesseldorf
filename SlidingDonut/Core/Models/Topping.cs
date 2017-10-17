namespace Core.Models
{
    public class Topping : Entity
    {
        public string Color { get; set; }
        public int DonutId { get; set; }
        public Donut Donut { get; set; }
    }
}