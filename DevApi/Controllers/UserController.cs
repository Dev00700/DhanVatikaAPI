using DevApi.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using MyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService auserService)
        {
            userService = auserService;
        }

        // POST: api/User
        [HttpPost("AddUserService")]
        public async Task< ActionResult<CommonResponseDto<ValidationMessageDto>>> InsertUser([FromBody] CommonRequestDto<UserDto> request)
        {
            var result = await userService.AddService(request);
            return result;
        }

        // PUT: api/User/{id}
        [HttpPost("UpdateUserService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> UpdateUser( [FromBody] CommonRequestDto<UserDto> request)
        {
            var result =await  userService.UpdateService(request);
            return result;
        }

        // GET: api/User
        [HttpPost("GetUserListService")]
        public async Task<ActionResult<CommonResponseDto<List<UserDto>>>> GetListUsers(CommonRequestDto request)
        {
            var users = await userService.GetListService(request);
           return users;
        }

        // GET: api/User/{id}
        [HttpPost("GetUserService")]
        public async Task<ActionResult<CommonResponseDto<UserDto>>> GetUser([FromBody] CommonRequestDto<UserReqDto> request)
        {
            var user =await  userService.GetUser(request);
           return user;
        }
    }
}