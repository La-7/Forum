using Forum.Web.Models.ThemeViewModels;
using System.Collections.Generic;

namespace Forum.Web.Models.Theme
{
    public class ThemeIndexModel
    {
        public IEnumerable<ThemeModel> ThemeList { get; set; } 
    }
}
