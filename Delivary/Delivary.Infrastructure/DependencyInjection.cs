using Delivary.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Delivary.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PizzaDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Database"),
                b => b.MigrationsAssembly(typeof(PizzaDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IPizzaDbContext>(provider => provider.GetService<PizzaDbContext>());
        }
    }
}
