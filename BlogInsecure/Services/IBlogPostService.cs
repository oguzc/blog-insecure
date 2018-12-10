using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogInsecure.Models;

namespace BlogInsecure.Services
{
    public interface IBlogPostService
    {
        Task<BlogPostListViewModel> GetBlogPostList();
        Task<BlogPostDetailViewModel> GetBlogPostDetail(int blogPostId);
        Task<bool> AddComment(BlogPostCommentDto blogPostCommentDto);
    }
}
