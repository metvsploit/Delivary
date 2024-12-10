using AutoMapper;
using Delivary.Application.Interfaces;
using Delivary.Application.Models;
using Delivary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Delivary.Application.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaDbContext _db;
        private readonly IMapper _mapper;

        public PizzaService(IPizzaDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Pizza> Create(PizzaDTO model)
        {
            var pizza = _mapper.Map<Pizza>(model);

            await _db.Pizzas.AddAsync(pizza);
            await _db.SaveChangesAsync();

            return pizza;
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var pizza = await _db.Pizzas.FirstOrDefaultAsync(x => x.Id == id);
                if (pizza == null)
                {
                    throw new Exception("Пицца не найдена");
                }

                _db.Pizzas.Remove(pizza);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Edit(Pizza model)
        {
            try
            {
                _db.Pizzas.Update(model);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Pizza>> GetAll()
        {
            try
            {
                var result = await _db.Pizzas.AsNoTracking().ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Pizza> GetById(Guid id)
        {
            try
            {
                var pizza = await _db.Pizzas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                return pizza;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
