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

        public async Task<BlogPostDetailViewModel> GetBlogPostDetail(int blogPostId)
        {
            var requestMessage = _apiClient.CreateGetRequest($"{_appSettings.BlogApiUrl}{BasePath}/BlogPostDetail?blogPostId={blogPostId}");
            var response = await _apiClient.SendAsync(requestMessage);
            string responseBody = await response.Content.ReadAsStringAsync();
            var blogPostList = JsonConvert.DeserializeObject<BlogPostDetailViewModel>(responseBody);
            return blogPostList;
        }

        public async Task<BlogPostListViewModel> GetBlogPostList()
        {
            var requestMessage = _apiClient.CreateGetRequest($"{_appSettings.BlogApiUrl}{BasePath}/BlogPostList");
            var response = await _apiClient.SendAsync(requestMessage);
            string responseBody = await response.Content.ReadAsStringAsync();
            var blogPostList = JsonConvert.DeserializeObject<BlogPostListViewModel>(responseBody);
            return blogPostList;
        }

        public async Task AddComment(BlogPostCommentDto blogPostCommentDto)
        {
            var requestMessage = _apiClient.CreatePostRequest($"{_appSettings.BlogApiUrl}{BasePath}/AddComment", blogPostCommentDto);
            var response = await _apiClient.SendAsync(requestMessage);
            string responseBody = await response.Content.ReadAsStringAsync();
        }
    }
}
