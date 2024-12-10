using Delivary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Delivary.Application.Interfaces
{
    public interface IPizzaDbContext
    {
        DbSet<Pizza> Pizzas { get; set; }
        Task<int> SaveChangesAsync();
    }
}
