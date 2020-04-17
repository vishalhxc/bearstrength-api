using BearstrengthApi.Controller;
using BearstrengthApi.Model;
using BearstrengthApi.User.Dto;
using BearstrengthApi.User.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BearstrengthApi.Tests.Controller
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> mockUserService;
        private readonly UserController userController;

        public UserControllerTests()
        {
            mockUserService = new Mock<IUserService>();
            userController = new UserController(mockUserService.Object);
        }

        [Fact(DisplayName = "Create user, happy path, endpoint calls user service and returns response")]
        public void CreateUser_CallsRepository()
        {
            var input = new UserRequest
            {
                Username = "user1",
                Email = "user1@bearstrength.com",
                FullName = "user 1"
            };
            var expectedStatus = 201;
            var expected = new DetailResponse<UserResponse>
            {
                Status = 201,
                Detail = new UserResponse
                {
                    Username = "user1",
                    Email = "user1@bearstrength.com",
                    FullName = "user 1"
                }
            };
            var convertedDto = new UserDto
            {
                Username = "user1",
                Email = "user1@bearstrength.com",
                FullName = "user 1"
            };

            mockUserService.Setup(service => service.CreateUser(input))
                .Returns(convertedDto);

            // act
            var actual = userController.CreateUser(input).Result
                as CreatedResult;

            // assert
            Assert.Equal(expected, actual.Value);
            Assert.Equal(expectedStatus, actual.StatusCode);
            mockUserService.Verify(service => service.CreateUser(input), Times.Once);
            mockUserService.VerifyNoOtherCalls();
        }
    }
}
