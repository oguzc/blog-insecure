using System.Threading.Tasks;
using Admin.Api.Models;

namespace Admin.Api.Services
{
    public interface IBlogPostRepository
    {
        Task<int> AddBlogPost(BlogPost blogPost);
    }
}
