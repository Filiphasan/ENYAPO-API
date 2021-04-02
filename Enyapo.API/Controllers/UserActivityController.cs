using Enyapo.Core.Dtos;
using Enyapo.Core.Service;
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
    public class UserActivityController : CustomBaseController
    {
        private readonly IUserActivityService _userActivityService;

        public UserActivityController(IUserActivityService userActivityService)
        {
            _userActivityService = userActivityService;
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserActivityDto createUserActivityDto)
        {
            var result = await _userActivityService.AddAsync(createUserActivityDto);
            return ActionResultInstance(result);
        }
        [HttpGet("activity/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userActivityService.Where(x => x.ActivityId == id);
            return ActionResultInstance(result);
        }
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var result = await _userActivityService.Where(x => x.UserAppId == id);
            return ActionResultInstance(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userActivityService.Remove(id);
            return ActionResultInstance(result);
        }
    }
}
