using Delivary.Infrastructure;
using Delivary.Test.CustomerTest;
using Delivary.Test.OrderTest;
using Delivary.Test.PizzaTest;
using Microsoft.EntityFrameworkCore;

namespace Delivary.Test
{
    public class TestDataFixture : IDisposable
    {
        private static bool _isInit;
        public DbContextOptions<PizzaDbContext> PizzaOptions { get; private set; }
        public TestDataFixture()
        {
            var builder = new DbContextOptionsBuilder<PizzaDbContext>()
                .UseInMemoryDatabase(databaseName: "Test Database")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(Console.WriteLine);

            PizzaOptions = builder.Options;

            using var context = new PizzaDbContext(PizzaOptions);

            context.Pizzas.AddRange(PizzaData.Get());
            context.Customers.AddRange(CustomerData.Get());
            context.Orders.AddRange(OrderData.Get());
            //PizzaData.UnDetached(Context);

            context.SaveChanges();
        }
        public void Dispose()
        {
        }
    }
}
