using System;
using System.Collections.Generic;

namespace Forum.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public virtual User User { get; set; }
        public virtual Theme Theme { get; set; }

        public virtual IEnumerable<PostReply> Replies { get; set; }
    }
}
