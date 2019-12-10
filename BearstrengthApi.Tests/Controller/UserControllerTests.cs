using System;
using BearstrengthApi.Controller;
using BearstrengthApi.DAO;
using BearstrengthApi.Data.Repository;
using BearstrengthApi.DTO;
using BearstrengthApi.Entity;
using BearstrengthApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BearstrengthApi.Tests.Controller
{
    public class UserControllerTests
    {
        private const string Username = "username";
        private const string Email = "email";
        private const string FullName = "fullName";

        private Mock<ILogger<UserController>> mockLogger;
        private Mock<IUserService> mockUserService;
        private UserController userController;
        private UserDto userDto;

        public UserControllerTests()
        {
            mockLogger = new Mock<ILogger<UserController>>();
            mockUserService = new Mock<IUserService>();

            userController = new UserController(mockLogger.Object, mockUserService.Object);

            userDto = new UserDto
            {
                Username = Username,
                Email = Email,
                FullName = FullName
            };
        }

        [Fact(DisplayName = "Create user endpoint calls user service")]
        public void CreateUser_CallsRepository()
        {
            mockUserService.Setup(
                repo => repo.CreateUser(It.IsAny<UserDto>())).Verifiable();

            IActionResult result = userController.CreateUser(userDto);

            //Assert.Equal(result.);

            mockUserService.Verify(service => service.CreateUser(userDto));
        }
    }
}
