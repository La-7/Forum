using Forum.Domain;
using Forum.Domain.Models;
using Forum.Web.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Forum.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUser _userService;

        public ProfileController(UserManager<User> userManager, IUser userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        
        public IActionResult Detail(string id)
        {
            var user = _userService.GetById(id);
            var userRoles = _userManager.GetRolesAsync(user).Result;

            var model = new ProfileModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                MemberSince = user.MemberSince,
                IsAdmin = userRoles.Contains("Admin")
            };

            return View(model);
        }

        public async Task<IActionResult> Ban(string id)
        {
            var user = _userService.GetById(id);

            await _userService.Ban(user);

            return RedirectToAction("Index", "Theme");
        }
    }
}
