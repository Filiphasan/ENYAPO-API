using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Core.Models
{
    public class UserActivity
    {
        public int Id { get; set; }
        public string UserAppId { get; set; }
        public int ActivityId { get; set; }
        public UserApp UserApp { get; set; }
        public Activity Activity { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public bool IsDelete { get; set; }
    }
}
