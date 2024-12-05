using Delivary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivary.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ComplexProperty(o => o.Address);

            builder.HasOne(x => x.Customer).WithMany(x => x.Orders);
            builder.HasMany(x => x.Pizzas);
        }
    }
}
