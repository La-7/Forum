using Forum.Domain;
using Forum.Domain.Models;
using Forum.Web.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Service
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserService(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(string id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id);
        }

        public async Task Ban(User user)
        {
            if (!user.IsBanned)
            {
                user.IsBanned = true;
                await _userManager.AddToRoleAsync(user, "banned_user");
            }
            else
            {
                user.IsBanned = false;
                await _userManager.RemoveFromRoleAsync(user, "banned_user");
            }

            await _context.SaveChangesAsync();
        }
    }
}
