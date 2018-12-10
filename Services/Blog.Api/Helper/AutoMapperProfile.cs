using AutoMapper;
using Blog.Api.Models;

namespace Blog.Api.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BlogPost, BlogPostDetailDto>();
        }
    }
}
