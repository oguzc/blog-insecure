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
            CreateMap<BlogPostDetailViewModel, BlogPostCommentDto>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(
                    from => from.BlogPostId,
                    to => to.MapFrom(m => m.Id));
        }
    }
}
