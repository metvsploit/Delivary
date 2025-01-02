using Delivary.Application.Models;
using Delivary.Domain.Entities;

namespace Delivary.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> Create(CustomerDTO model);
        Task<bool> Delete(Guid id);
        Task<bool> Edit(Customer customer);
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(Guid id);
    }
}
