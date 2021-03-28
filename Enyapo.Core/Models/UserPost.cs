using Enyapo.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Core.Models
{
    public class UserPost : EntityBase
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public int LikesCount { get; set; } = 0;
        public UserApp UserApp { get; set; }
    }
}
