using Microsoft.AspNetCore.Identity;
using System;

namespace Forum.Domain.Models
{
    public class User : IdentityUser
    {   
        public bool IsBanned { get; set; }
        public DateTime MemberSince { get; set; }
        public bool IsActive { get; set; }
    }
}
