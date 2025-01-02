using AutoMapper;
using Delivary.Application.Exceptions;
using Delivary.Application.Interfaces;
using Delivary.Application.Models;
using Delivary.Domain.Entities;
using Delivary.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Delivary.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IPizzaDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(IPizzaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Customer> Create(CustomerDTO model)
        {
            var customer = _mapper.Map<Customer>(model);

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<bool> Delete(Guid id)
        {
            var customer = await GetById(id);

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Edit(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Customer>> GetAll()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetById(Guid id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                throw new AppException($"Клиент с идентификатором \"{id}\" не найден", "Клиент не найден");
            }

            return customer;
        }
    }
}
