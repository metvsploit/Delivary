using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Delivary.Application.Exceptions;
using Delivary.Application.Extensions;
using Delivary.Application.Interfaces;
using Delivary.Application.Models;
using Delivary.Domain.Consts;
using Delivary.Domain.Documents;
using Delivary.Domain.Entities;
using Elastic.Clients.Elasticsearch;
using Microsoft.EntityFrameworkCore;

namespace Delivary.Application.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaDbContext _db;
        private readonly IMapper _mapper;
        private readonly IElasticSearch _elasticSearch;

        public PizzaService(IPizzaDbContext db, IMapper mapper, IElasticSearch elasticSearch)
        {
            _db = db;
            _mapper = mapper;
            _elasticSearch = elasticSearch;
        }

        public async Task<Pizza> Create(PizzaDTO model)
        {
            var pizza = _mapper.Map<Pizza>(model);

            await _db.Pizzas.AddAsync(pizza);

            var pizzaDoc = _mapper.Map<PizzaDocument>(pizza);

            var response = await _elasticSearch.Client.CreateAsync(pizzaDoc, x => x.Index(PizzaConst.PizzaIndex));
            if(!response.IsSuccess())
            {
                throw new AppException($"Возникла ошибка при выполнении запроса", "Возникла ошибка при выполнении запроса\"");
            }

            await _db.SaveChangesAsync();

            return pizza;
        }

        public async Task<bool> Delete(Guid id)
        {
            var pizza = await _db.Pizzas.FirstOrDefaultAsync(x => x.Id == id);
            if (pizza == null)
            {
                throw new AppException($"Пицца с идентификатором \"{id}\" не найдена", "Пицца не найдена");
            }

            _db.Pizzas.Remove(pizza);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Edit(Pizza model)
        {
            _db.Pizzas.Update(model);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<List<Pizza>> GetAll()
        {
            var result = await _db.Pizzas.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Pizza> GetById(Guid id)
        {
            var pizza = await _db.Pizzas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return pizza;
        }

        public async Task<List<Pizza>> GetByPagination(int page, int size)
        {
            var pizzas = await _db.Pizzas.Pagination(page, size).ToListAsync();
            return pizzas;
        }

        public async Task<List<Pizza>> GetByPrefix(string prefix)
        {
            var response = await _elasticSearch.Client.SearchAsync<PizzaDocument>(s =>
            {
                s.Index(PizzaConst.PizzaIndex)
                .Query(q =>
                {
                    q.Prefix(t => t.Field(x => x.Name).Value(prefix));
                });
            });

            var documentIds = response.Documents.Select(x => x.Id);
            if(documentIds.Count() == 0)
            {
                return new List<Pizza>();
            }

            var pizzas = await _db.Pizzas.Where(x => documentIds.Contains(x.Id)).ToListAsync();

            return pizzas;
        }
    }
}
