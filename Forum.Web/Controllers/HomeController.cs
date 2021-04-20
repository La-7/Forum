using Forum.Domain;
using Forum.Domain.Models;
using Forum.Web.Models;
using Forum.Web.Models.Home;
using Forum.Web.Models.Post;
using Forum.Web.Models.ThemeViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Forum.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _postService;

        public HomeController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexModel();
            return View(model);
        }

        private object BuildHomeIndexModel()
        {
            var latestPosts = _postService.GetLatestPosts(10);

            var posts = latestPosts.Select(post => new PostModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorName = post.User.UserName,
                AuthorId = post.User.Id,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Theme = GetThemeListingForPost(post)
            });

            return new HomeIndexModel
            {
                LatestPost = posts
            };
        }

        private ThemeModel GetThemeListingForPost(Post post)
        {
            var theme = post.Theme;

            return new ThemeModel
            {
                Id = theme.Id,
                Name = theme.Title
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
