﻿using Enyapo.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Core.Models
{
    public class UserRefreshToken
    {
        public string UserId { get; set; }
        public string Code { get; set; } 
        public DateTime Expiration { get; set; }
    }
}
