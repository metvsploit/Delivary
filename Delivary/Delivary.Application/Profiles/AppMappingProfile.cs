using AutoMapper;
using Delivary.Application.Models;
using Delivary.Domain.Documents;
using Delivary.Domain.Entities;

namespace Delivary.Application.Profiles
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() {
            CreateMap<PizzaDTO, Pizza>();
            CreateMap<Pizza, PizzaDocument>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<OrderItemDTO, OrderItem>();
            CreateMap<OrderDTO, Order>();
        }
    }
}
