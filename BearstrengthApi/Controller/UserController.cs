using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BearstrengthApi.Data.Repository;
using BearstrengthApi.DTO;
using BearstrengthApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BearstrengthApi.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger,
                              IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        public void CreateUser(UserDto user)
        {
            _userService.CreateUser(user);

        }
    }
}
