using Delivary.Application.Models;
using Delivary.Domain.Entities;

namespace Delivary.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Order> Create(OrderDTO model);
        Task<bool> Delete(Guid id);
        Task<bool> Edit(Order order);
        Task<List<Order>> GetAll();
        Task<Order> GetById(Guid id);
    }
}
