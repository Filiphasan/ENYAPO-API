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
        public string UserId { get; set; }
        public string Content { get; set; }
        public virtual DateTime CreatedTime { get; set; }
        public virtual DateTime ModifiedTime { get; set; }
    }
}
