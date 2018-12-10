using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using BlogInsecure.Config;
using BlogInsecure.Models;
using BlogInsecure.Services;
using System.Threading.Tasks;

namespace BlogInsecure.Controllers
{
    public class HomeController : Controller
    {
        IBlogPostService _blogPostService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public HomeController(
            IBlogPostService blogPostService,
            IMapper mapper,
            AppSettings appSettings)
        {
            _blogPostService = blogPostService;
            _mapper = mapper;
            _appSettings = appSettings;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BlogPosts()
        {
            var blogPostList = await _blogPostService.GetBlogPostList();
            return View(blogPostList);
        }

        public async Task<IActionResult> BlogPostDetail(int blogPostId)
        {
            var blogPostDetail = await _blogPostService.GetBlogPostDetail(blogPostId);
            return View(blogPostDetail);
        }

        [HttpPost]
        public async Task<IActionResult> BlogPostDetail([FromForm]BlogPostDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                // map dto to entity
                var userDto = _mapper.Map<BlogPostCommentDto>(model);

                // save
                await _blogPostService.AddComment(userDto);
                return RedirectToAction("BlogPostDetail", new { blogPostId = model.Id });
            }

            return View(model);
        }
    }
}
