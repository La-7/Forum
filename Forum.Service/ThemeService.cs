using Forum.Domain;
using Forum.Domain.Models;
using Forum.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Service
{
    public class ThemeService : ITheme
    {
        private readonly ApplicationDbContext _context;

        public ThemeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Theme> GetAll()
        {
            return _context.Themes
                .Include(theme => theme.Posts);
        }

        public Theme GetById(int id)
        {
            var theme = _context.Themes.Where(t => t.Id == id)
                                .Include(f => f.Posts).ThenInclude(p => p.User)
                                .Include(f => f.Posts).ThenInclude(p => p.Replies).ThenInclude(r => r.User)
                                .FirstOrDefault();

            return theme;
        }
    }
}
