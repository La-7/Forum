using System.Collections.Generic;

namespace Forum.Web.Models.User
{
    public class ProfileListModel
    {
        public IEnumerable<ProfileModel> Profiles { get; set; }
    }
}
