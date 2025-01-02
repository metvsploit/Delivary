using Delivary.Application.Models;
using Delivary.Domain.Entities;

namespace Delivary.Application.Interfaces
{
    public interface IPizzaService
    {
        Task<Pizza> Create(PizzaDTO model);
        Task<bool> Delete(Guid id);
        Task<bool> Edit(Pizza model);
        Task<List<Pizza>> GetAll();
        Task<Pizza> GetById(Guid id);
        Task<List<Pizza>> GetByPagination(int page, int size);
        Task<List<Pizza>> GetByPrefix(string prefix);
    }
}
