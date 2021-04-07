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
    public class UserPostController : CustomBaseController
    {
        private readonly IUserPostService _userPostService;

        public UserPostController(IUserPostService userPostService)
        {
            _userPostService = userPostService;
        }
        [HttpPost]
        public async Task<IActionResult> AddPost(CreateUserPostDto createUserPostDto)
        {
            var result = await _userPostService.AddAsync(createUserPostDto);
            return ActionResultInstance(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePost(UpdateUserPostDto updateUserPostDto)
        {
            var result = await _userPostService.Update(updateUserPostDto);
            return ActionResultInstance(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            var result = await _userPostService.Where(x => x.IsDelete == false);
            return ActionResultInstance(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var result = await _userPostService.GetByIdAsync(id);
            return ActionResultInstance(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result = await _userPostService.Remove(id);
            return ActionResultInstance(result);
        }


        [HttpGet("like")]
        public async Task<IActionResult> GetUserPostWithLikesCount()
        {
            //var result = await _userPostService.Where(x => x.LikesCount > 5);
            //return ActionResultInstance(result);

            var result = await _userPostService.WhereMany(x => x.LikesCount > 5, x => x.Id > 9, x => x.Content.Length > 2);
            return ActionResultInstance(result);
        }
    }
}
