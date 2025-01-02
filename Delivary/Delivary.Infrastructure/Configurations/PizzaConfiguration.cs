using Delivary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivary.Infrastructure.Configurations
{
    public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
