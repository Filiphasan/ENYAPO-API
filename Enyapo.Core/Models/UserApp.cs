using Enyapo.Shared.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Core.Models
{
    public class UserApp : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string PPPath { get; set; }
        public ICollection<UserPost> UserPosts { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public ICollection<UserActivity> UserActivities { get; set; }

    }
}
