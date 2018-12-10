using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogInsecure.Models;

namespace BlogInsecure.Services
{
    public interface IBlogPostService
    {
        BlogPostListViewModel GetBlogPostList();
        BlogPostDetailViewModel GetBlogPostDetail(int blogPostId);
        bool AddComment(BlogPostCommentDto blogPostCommentDto);
    }
}
