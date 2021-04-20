using Forum.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Domain
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetPostsByTheme(int id);
        IEnumerable<Post> GetLatestPosts(int nPosts);


        Task Add(Post post);
        Task Delete(Post post);
        Task AddReply(PostReply reply);
        Task DeleteReply(PostReply post);
    }
}
