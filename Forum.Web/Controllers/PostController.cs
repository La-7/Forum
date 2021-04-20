using Forum.Domain;
using Forum.Domain.Models;
using Forum.Web.Models.Post;
using Forum.Web.Models.Reply;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly ITheme _themeService;

        private static UserManager<User> _userManager;

        public PostController(IPost postService, ITheme themeService, UserManager<User> userManager)
        {
            _postService = postService;
            _themeService = themeService;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);
            var replies = BuildPostReplies(post.Replies);

            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title, 
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                Created = post.Created,
                PostContent = post.Content,
                Replies = replies
            };

            return View(model);
        }

        [Authorize]
        public IActionResult Create(int id)
        {
            var theme = _themeService.GetById(id);

            var model = new NewPostModel
            {
                ThemeName = theme.Title,
                ThemeId = theme.Id,
                AuthorName = User.Identity.Name
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;
            var post = BuildPost(model, user);

            await _postService.Add(post);

            return RedirectToAction("Index", "Post", new { id = post.Id });
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = _postService.GetById(id);

            await _postService.Delete(post);
                
            return RedirectToAction("Index", "Theme");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteReply(int id, int replyId)
        {
            var post = _postService.GetById(id);
            var postReplies = post.Replies.ToList();

            await _postService.DeleteReply(postReplies[replyId]); // DBCC CHECKIDENT (PostReplies, Reseed, 0)

            return RedirectToAction("Index", "Post", new { id = id });
        }

        private Post BuildPost(NewPostModel model, User user)
        {
            var theme = _themeService.GetById(model.ThemeId);

            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                User = user,
                Theme = theme
            };
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                AuthorId = reply.User.Id,
                AuthorName = reply.User.UserName,
                Created = reply.Created, 
                ReplyContent = reply.Content
            });
        }
    }
}
