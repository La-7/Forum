using Forum.Domain.Models;
using System.Collections.Generic;

namespace Forum.Domain
{
    public interface ITheme
    {
        Theme GetById(int id);
        IEnumerable<Theme> GetAll();
    }
}
