using AutoMapper;
using Delivary.Application.Models;
using Delivary.Domain.Entities;

namespace Delivary.Application.Profiles
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() {
            CreateMap<PizzaDTO, Pizza>();
        }
    }
}
