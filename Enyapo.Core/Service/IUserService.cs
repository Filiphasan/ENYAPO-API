using Enyapo.Core.Dtos;
using Enyapo.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Core.Service
{
    public interface IUserService
    {
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserAppDto createUserAppDto);
        Task<Response<UserAppDto>> GetUserByNameAsync(string userName);
    }
}
