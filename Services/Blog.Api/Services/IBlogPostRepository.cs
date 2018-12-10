using System.Threading.Tasks;
using System.Collections.Generic;
using Blog.Api.Models;

namespace Blog.Api.Services
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetBlogPostList();
        Task<BlogPost> GetBlogPostDetail(int blogPostId);
        Task<bool> AddComment(BlogPostComment blogPostComment);
        Task<IEnumerable<BlogPostComment>> GetBlogPostCommentList(int blogPostId);
    }
}
