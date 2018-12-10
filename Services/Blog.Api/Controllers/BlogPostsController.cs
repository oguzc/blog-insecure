using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
//using Blog.Api.Config;
//using Blog.Api.Helpers;
using Blog.Api.Models;
using Blog.Api.Services;

namespace Blog.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class BlogPostsController : Controller
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private IMapper _mapper;

        public BlogPostsController(
            IBlogPostRepository blogPostRepository,
            IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> BlogPostList()
        {
            var blogPostList = await _blogPostRepository.GetBlogPostList();
            var blogPostListDto = new BlogPostListDto
            {
                BlogPosts = blogPostList.ToList()
            };
            return Ok(blogPostListDto);
        }

        public async Task<IActionResult> BlogPostDetail(int blogPostId)
        {
            var blogPostDetail = await _blogPostRepository.GetBlogPostDetail(blogPostId);
            return Ok(blogPostDetail);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody]BlogPostComment blogPostComment)
        {
            await _blogPostRepository.AddComment(blogPostComment);
            return Ok();
        }
    }
}