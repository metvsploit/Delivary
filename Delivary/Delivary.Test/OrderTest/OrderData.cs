using Delivary.Domain.Entities;
using Delivary.Domain.ValueObjects;
using Delivary.Test.CustomerTest;
using Delivary.Test.PizzaTest;

namespace Delivary.Test.OrderTest
{
    public class OrderData
    {
        private static List<Order> _orders = new();
        public static Guid Id;

        public static List<Order> Get()
        {
            if (_orders.Count > 0)
            {
                return _orders;
            }

            var customers = CustomerData.Get();
            var pizzas = PizzaData.Get();

            for (int i = 1; i <= 4; i++)
            {
                var order = new Order
                {
                    Id = Guid.NewGuid(),
                    Address = new Address($"City{i}", $"Street{i}"),
                    CreatedDate = DateTime.UtcNow,
                    CustomerId = customers[i].Id,
                    Pizzas = new List<OrderItem>()
                };

                order.Pizzas.Add(new OrderItem { OrderId = order.Id, Count = 2, PizzaId = pizzas[i].Id });
                order.Pizzas.Add(new OrderItem { OrderId = order.Id, Count = 2, PizzaId = pizzas[0].Id });

                _orders.Add(order);
            }

            Id = _orders[0].Id;

            return _orders;
        }
    }
}
