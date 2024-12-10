using Delivary.Infrastructure;
using Delivary.Test.PizzaTest;
using Microsoft.EntityFrameworkCore;
namespace Delivary.Test
{
    public class TestDataFixture : IDisposable
    {
        public DbContextOptions<PizzaDbContext> PizzaOptions { get; set; }
        public TestDataFixture()
        {
            var builder = new DbContextOptionsBuilder<PizzaDbContext>()
                .UseInMemoryDatabase(databaseName: "Test Database")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(Console.WriteLine);

            PizzaOptions = builder.Options;

            using var context = new PizzaDbContext(PizzaOptions);

            context.Pizzas.AddRange(PizzaData.Get());
            //PizzaData.UnDetached(Context);

            context.SaveChanges();
        }
        public void Dispose()
        {
        }
    }
}
