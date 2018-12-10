using AutoMapper;
using BlogInsecure.Models;

namespace BlogInsecure.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, RegisterViewModel>();
            CreateMap<RegisterViewModel, UserDto>();
            CreateMap<UserDto, LoginViewModel>();
            CreateMap<LoginViewModel, UserDto>();
        }
    }
}
