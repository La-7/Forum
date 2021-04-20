using System;

namespace Forum.Web.Models.Reply
{
    public class PostReplyModel
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime Created { get; set; }
        public string ReplyContent { get; set; }
        public bool IsAuthorAdmin { get; set; }

        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }

        public string ThemeName { get; set; }
        public int ThemeId { get; set; }
    }
}
