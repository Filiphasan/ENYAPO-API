using Enyapo.Core.Dtos;
using Enyapo.Core.Models;
using Enyapo.Core.Service;
using Enyapo.Service.Mapper;
using Enyapo.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;

        public UserService(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<UserAppDto>> CreateUserAsync(CreateUserAppDto createUserAppDto)
        {
            var user = new UserApp
            {
                UserName = createUserAppDto.UserName,
                Email = createUserAppDto.Email,
                FirstName = createUserAppDto.FirstName,
                LastName = createUserAppDto.LastName
            };
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return Response<UserAppDto>.Fail(new ErrorDto(errors,true),404);
            }
            var userDto = ObjectMapper.Mapper.Map<UserAppDto>(user);
            return Response<UserAppDto>.Success(userDto,200);
        }

        public async Task<Response<UserAppDto>> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Response<UserAppDto>.Fail("User is not found!",404,true);
            }
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }

        public async Task<Response<UserAppDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Response<UserAppDto>.Fail("User is not found", 404, true);
            }
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }
    }
}
