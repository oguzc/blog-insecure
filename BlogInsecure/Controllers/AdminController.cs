using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using BlogInsecure.Config;
using BlogInsecure.Models;
using BlogInsecure.Services;
using System.Threading.Tasks;

namespace BlogInsecure.Controllers
{
    public class AdminController : Controller
    {
        IAdminService _adminService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AdminController(IAdminService adminService,
            IMapper mapper,
            AppSettings appSettings)
        {
            _adminService = adminService;
            _mapper = mapper;
            _appSettings = appSettings;
        }

        public async Task<IActionResult> Index(string username)
        {
            var token = HttpContext.Session.GetString(username);
            await _adminService.CanCreatePost(token);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm]CreatePostViewModel model, string username)
        {
            if (ModelState.IsValid)
            {
                var blogPostDto = _mapper.Map<BlogPostDto>(model);

                var token = HttpContext.Session.GetString(username);
                await _adminService.CreatePost(blogPostDto, token);

                return RedirectToAction("Index", new { username = username });
            }

            return View(model);
        }

        public IActionResult Authenticate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromForm]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = _mapper.Map<UserDto>(model);

                var authenticationDto = await _adminService.Authenticate(userDto);
                HttpContext.Session.SetString(model.Username, authenticationDto.Token);
                return RedirectToAction("Index", new { username = model.Username });
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // map dto to entity
                var userDto = _mapper.Map<UserDto>(model);

                // save
                _adminService.Register(userDto);
                return RedirectToAction("Authenticate");
            }

            return View(model);
        }
    }
}