using Delivary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Delivary.Application.Interfaces
{
    public interface IPizzaDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Pizza> Pizzas { get; set; }
        Task<int> SaveChangesAsync();
    }
}
