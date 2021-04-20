using Forum.Domain;
using Forum.Domain.Models;
using Forum.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task AddReply(PostReply reply)
        {
            _context.Add(reply);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Post post)
        {
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReply(PostReply postReply)
        {
            _context.Remove(postReply);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts
                           .Include(post => post.User)
                           .Include(post => post.Replies).ThenInclude(reply => reply.User)
                           .Include(post => post.Theme);
        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(post => post.Id == id)
                                 .Include(post => post.User)
                                 .Include(post => post.Replies)
                                        .ThenInclude(reply => reply.User)
                                 .Include(post => post.Theme)
                                 .First();
        }

        public IEnumerable<Post> GetLatestPosts(int nPosts)
        {
            return GetAll().OrderByDescending(post => post.Created).Take(nPosts);
        }

        public IEnumerable<Post> GetPostsByTheme(int id)
        {
            return _context.Themes
                .Where(theme => theme.Id == id)
                .First().Posts;
        }
    }
}
