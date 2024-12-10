using Delivary.Domain.ValueObjects;

namespace Delivary.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<OrderItem> Pizzas { get; set; } = [];
        public Customer Customer { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public Guid CustomerId {  get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletionDate {  get; set; }
        public bool Completed { get; set; }
    }
}
