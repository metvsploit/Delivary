using AutoMapper;
using Delivary.Application.Profiles;

namespace Delivary.Test
{
    public static class Configuration
    {
        private static IMapper _mapper;

        public static IMapper GetAutoMapper()
        {
            if(_mapper != null)
            {
                return _mapper;
            }

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AppMappingProfile());
            });

            _mapper = mockMapper.CreateMapper();

            return _mapper;
        }
    }
}
