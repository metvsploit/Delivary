namespace Delivary.Domain.Entities
{
    public class OrderItem
    {
        public Guid OrderId { get; set; } 
        public Guid PizzaId { get; set; }
        public Pizza Pizza { get; set; } = null!;
        public int Count { get; set; }
    }
}
