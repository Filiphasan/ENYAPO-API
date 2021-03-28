using Enyapo.Core.Dtos;
using Enyapo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Core.Service
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);
    }
}
