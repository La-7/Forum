using Forum.Web.Models.Post;
using Forum.Web.Models.ThemeViewModels;
using System.Collections.Generic;

namespace Forum.Web.Models.Theme
{
    public class TopicModel
    {
        public ThemeModel Theme { get; set; }
        public IEnumerable<PostModel> Posts { get; set; }
    }
}
