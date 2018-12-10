using System.Threading.Tasks;
using System.Collections.Generic;
using BlogInsecure.Client;
using BlogInsecure.Config;
using BlogInsecure.Models;
using Newtonsoft.Json;

namespace BlogInsecure.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IHttpClient _apiClient;
        private readonly AppSettings _appSettings;
        private const string BasePath = "BlogPosts";

        public BlogPostService(
            IHttpClient httpClient,
            AppSettings appSettings)
        {
            _apiClient = httpClient;
            _appSettings = appSettings;
        }

        public BlogPostDetailViewModel GetBlogPostDetail(int blogPostId)
        {
            return new BlogPostDetailViewModel
            {
                Id=1,
                Title="title 1",
                Content="comment 1"
            };
        }

        public BlogPostListViewModel GetBlogPostList()
        {
            return new BlogPostListViewModel()
            {
                BlogPosts = new List<BlogPostDto>
                {
                    new BlogPostDto
                    {
                        Id=1,
                        Title="title 1",
                        Content="comment 1"
                    }
                }
            };
        }

        public bool AddComment(BlogPostCommentDto blogPostCommentDto)
        {
            return true;
        }
    }
}
