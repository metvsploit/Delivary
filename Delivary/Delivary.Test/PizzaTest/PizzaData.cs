using Delivary.Domain.Entities;
using Delivary.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Delivary.Test.PizzaTest
{
    public static class PizzaData
    {
        public static Guid Id = Guid.NewGuid();
        private static List<Pizza> _pizzaList = new();
        public static List<Pizza> Get()
        {
            if(_pizzaList.Count > 0)
            {
                return _pizzaList;
            }

            var random = new Random();

            for (int i = 1; i < 10; i++)
            {
                var pizza = new Pizza
                {
                    Name = $"Pizza {i}",
                    Description = $"Pizza Decription",
                    Price = random.Next(100, 900)
                };

                _pizzaList.Add(pizza);
            }

            _pizzaList[0].Id = Id;
            return _pizzaList;
        }

        public static void UnDetached(PizzaDbContext context)
        {
            foreach(var pizza in _pizzaList)
            {
                context.Entry(pizza).State = EntityState.Detached;
            }
        }
    }
}
