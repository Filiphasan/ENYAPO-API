﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Core.Dtos
{
    public class CreateUserPostDto
    {
        public string UserAppId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
