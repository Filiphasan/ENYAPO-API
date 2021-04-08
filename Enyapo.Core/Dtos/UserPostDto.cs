using Enyapo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Core.Dtos
{
    public class UserPostDto
    {
        public int Id { get; set; }
        public string UserAppId { get; set; }
        public string Content { get; set; }
        public int LikesCount { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public UserAppDto UserAppDto { get; set; }
    }
}
