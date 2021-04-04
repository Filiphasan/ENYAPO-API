using Enyapo.API.Utility;
using Enyapo.Core.Dtos;
using Enyapo.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enyapo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserAppDto createUserAppDto)
        {
            try
            {
                var result = await _userService.CreateUserAsync(createUserAppDto);
                if (result.Error != null)
                {
                    return Ok(UserMessages.UserMessagesFunction(2, General.USERCREATE));
                }
                else
                {
                    return Ok(UserMessages.UserMessagesFunction(1, General.USERCREATE));
                }

            }
            catch (Exception)
            {
                return BadRequest(UserMessages.UserMessagesFunction(2, General.USERCREATE));
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserByName()
        {
            var result = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);
            return ActionResultInstance(result);
        }
    }
}
