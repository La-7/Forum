using Forum.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Domain
{
    public interface IUser
    {
        User GetById(string id);
        IEnumerable<User> GetAll();
        Task Ban(User user);
    }
}
