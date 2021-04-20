    using Forum.Web.Models.ThemeViewModels;

namespace Forum.Web.Models.Post
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string AuthorId { get; set; }
        public string DatePosted { get; set; }

        public ThemeModel Theme { get; set; }

        public int RepliesCount { get; set; }
    }
}
