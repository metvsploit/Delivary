using AutoMapper;
using Delivary.Application.Exceptions;
using Delivary.Application.Interfaces;
using Delivary.Application.Models;
using Delivary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Delivary.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IPizzaDbContext _context;
        private readonly ICustomerService _customerService;

        public OrderService(IPizzaDbContext context, IMapper mapper, ICustomerService customerService)
        {
            _context = context;
            _mapper = mapper;
            _customerService = customerService;
        }

        public async Task<Order> Create(OrderDTO model)
        {
            var customer = await _customerService.GetById(model.CustomerId);
            var order = _mapper.Map<Order>(model);

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<bool> Delete(Guid id)
        {
            var order = await GetById(id);

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Edit(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Order>> GetAll()
        {
            var orders = await _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Pizzas)
                .ThenInclude(x => x.Pizza)
                .ToListAsync();

            return orders;
        }

        public async Task<Order> GetById(Guid id)
        {
            var order = await _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Pizzas)
                .ThenInclude(x => x.Pizza)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                throw new AppException($"Заказ с идентификатором \"{id}\" не найден", "Заказ не найден");
            }

            return order;
        }
    }
}
