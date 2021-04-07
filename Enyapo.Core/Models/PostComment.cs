using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Core.Models
{
    public class PostComment
    {
        public int Id { get; set; }
        public int UserPostId { get; set; }
        public UserPost UserPost { get; set; }
        public string Comment { get; set; }
    }
}
