using Forum.Domain.Models;
using System.Collections.Generic;

namespace Forum.Web.Models.Reply
{
    public class PostReplyIndex
    {
        public string PostTitle { get; set; }
        public IEnumerable<PostReply> PostReplies { get; set; }
    }
}
