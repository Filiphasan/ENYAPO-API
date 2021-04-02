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
    public class ActivityController : CustomBaseController
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _activityService.Where(x => x.IsDelete == false);
            return ActionResultInstance(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _activityService.GetByIdAsync(id);
            return ActionResultInstance(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateActivityDto createActivityDto)
        {
            var result = await _activityService.AddAsync(createActivityDto);
            return ActionResultInstance(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateActivityDto updateActivityDto)
        {
            var result = await _activityService.Update(updateActivityDto);
            return ActionResultInstance(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _activityService.Remove(id);
            return ActionResultInstance(result);
        }
    }
}
