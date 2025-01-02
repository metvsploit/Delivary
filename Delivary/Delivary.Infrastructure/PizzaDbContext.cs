using Delivary.Application.Interfaces;
using Delivary.Domain.Entities;
using Delivary.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Delivary.Infrastructure
{
    public class PizzaDbContext : DbContext, IPizzaDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options) { 
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PizzaConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        }
    }
}
