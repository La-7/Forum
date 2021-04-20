using Forum.Domain;
using Forum.Domain.Models;
using Forum.Web.Models.Reply;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Forum.Web.Controllers
{
    [Authorize]
    public class ReplyController : Controller
    {
        private readonly IPost _postService;
        private readonly UserManager<User> _userManager;

        public ReplyController(IPost postService, UserManager<User> userManager)
        {
            _postService = postService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Create(int id)
        {
            var post = _postService.GetById(id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new PostReplyModel
            {
                 PostContent = post.Content,
                 PostTitle = post.Title,
                 PostId = post.Id,

                 AuthorId = user.Id,
                 AuthorName = User.Identity.Name,
                 IsAuthorAdmin = User.IsInRole("Admin"),

                 ThemeId = post.Theme.Id,
                 ThemeName = post.Theme.Title,
                 
                 Created = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(PostReplyModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var reply = BuildReply(model, user);

            await _postService.AddReply(reply);

            return RedirectToAction("Index", "Post", new { id = model.PostId });
        }

        private PostReply BuildReply(PostReplyModel model, User user)
        {
            var post = _postService.GetById(model.PostId);

            return new PostReply
            {
                Post = post,
                Content = model.ReplyContent,
                Created = DateTime.Now,
                User = user
            };
        }
    }
}
