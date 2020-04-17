using BearstrengthApi.Model;
using BearstrengthApi.User.Dto;
using BearstrengthApi.User.Service;
using Microsoft.AspNetCore.Mvc;

namespace BearstrengthApi.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<UserResponse> CreateUser(UserRequest user)
        {
            var userDto = _userService.CreateUser(user);
            return Created("CreateUser", ConvertToUserResponse(userDto));
        }

        private UserResponse ConvertToUserResponse(UserDto userDto)
        {
            return new UserResponse
            {
                Username = userDto.Username,
                Email = userDto.Email,
                FullName = userDto.FullName
            };
        }
    }
}
