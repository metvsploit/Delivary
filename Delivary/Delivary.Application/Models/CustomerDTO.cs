using Delivary.Domain.Entities;
using Delivary.Domain.ValueObjects;

namespace Delivary.Application.Models
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public Name Name { get; set; } = null!;
    }
}
