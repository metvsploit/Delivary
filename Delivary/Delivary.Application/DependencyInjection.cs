using Delivary.Application.Interfaces;
using Delivary.Application.Profiles;
using Delivary.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Delivary.Application
{
    public static class DependencyInjection
    {
        public static void AddBase(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppMappingProfile));
            services.AddSingleton<IElasticSearch, ElasticSearch>();
            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
