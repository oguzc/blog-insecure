using System.Threading.Tasks;
using BlogInsecure.Models;

namespace BlogInsecure.Services
{
    public interface IAdminService
    {
        Task<AuthenticationDto> Authenticate(UserDto userDto);
        Task Register(UserDto userDto);
        Task<bool> CanCreatePost(string token);
        Task CreatePost(BlogPostDto blogPostDto, string token);
    }
}