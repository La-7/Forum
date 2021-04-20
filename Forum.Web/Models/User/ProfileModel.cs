using System;

namespace Forum.Web.Models.User
{
    public class ProfileModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime MemberSince { get; set; }
    }
}
