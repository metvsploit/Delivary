using Delivary.Domain.Entities;
using Delivary.Domain.ValueObjects;

namespace Delivary.Application.Models
{
    public class OrderDTO
    {
        public List<OrderItemDTO> Pizzas { get; set; } = [];
        public Address Address { get; set; } = null!;
        public Guid CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
