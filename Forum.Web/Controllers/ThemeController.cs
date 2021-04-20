using Forum.Domain;
using Forum.Domain.Models;
using Forum.Web.Models.Post;
using Forum.Web.Models.Theme;
using Forum.Web.Models.ThemeViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Forum.Web.Controllers
{
    public class ThemeController : Controller
    {
        private readonly ITheme _themeService;

        public ThemeController(ITheme themeService)
        {
            _themeService = themeService;
        }

        public IActionResult Index()
        {
            var themes = _themeService.GetAll()
                .Select(theme => new ThemeModel
                {
                    Id = theme.Id,
                    Name = theme.Title,
                    Description = theme.Description
                });

            var model = new ThemeIndexModel
            {
                ThemeList = themes
            };

            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var theme = _themeService.GetById(id);
            var posts = theme.Posts;

            var postListing = posts.Select(post => new PostModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                Title = post.Title,
                AuthorName = post.User.UserName,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Theme = BuildThemeListing(post)
            });

            var model = new TopicModel
            {
                Posts = postListing,
                Theme = BuildThemeListing(theme)
            };

            return View(model);
        }

        private ThemeModel BuildThemeListing(Post post)
        {
            var theme = post.Theme;
            return BuildThemeListing(theme);
        }

        private ThemeModel BuildThemeListing(Theme theme)
        {
            return new ThemeModel
            {
                Id = theme.Id,
                Name = theme.Title,
                Description = theme.Description,
            };
        }
    }
}
