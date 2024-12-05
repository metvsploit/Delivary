﻿using Delivary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivary.Infrastructure.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ComplexProperty(x => x.Name, nameBuilder =>
            {
                nameBuilder.Property(x => x.FirstName).HasColumnName("FirstName");
                nameBuilder.Property(x => x.LastName).HasColumnName("LastName");
            });

            builder.HasMany(x => x.Orders).WithOne(x => x.Customer);
        }
    }
}
