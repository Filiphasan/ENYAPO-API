using Enyapo.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Core.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public string Thumbnail { get; set; }
        public string UserAppId { get; set; }
        public UserApp UserApp { get; set; }
        public ICollection<UserActivity> UserActivities { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public bool IsDelete { get; set; }
    }
}
