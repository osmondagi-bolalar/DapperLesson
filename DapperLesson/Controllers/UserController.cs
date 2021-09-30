using DapperLesson.Service.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperLesson.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        private readonly IUserService _userService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _userService.Get(Id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PersonModel model)
        {
            var result = await _userService.Create(model);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _userService.Delete(Id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int Id, PersonModel model)
        {
            var result = await _userService.Update(Id, model);
            return Ok(result);
        }
    }
}
