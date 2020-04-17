using BearstrengthApi.Model;
using BearstrengthApi.User.Dto;
using BearstrengthApi.User.Repository;
using BearstrengthApi.User.Service;
using Moq;
using Xunit;

namespace BearstrengthApi.Tests.Service
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> mockUserRepository;
        private readonly UserService userService;

        public UserServiceTests()
        {
            mockUserRepository = new Mock<IUserRepository>();
            userService = new UserService(mockUserRepository.Object);
        }

        [Fact(DisplayName = "Create user, happy path, calls Repository")]
        public void CreateUser_CallsRepository()
        {
            var input = new UserRequest
            {
                Username = "username",
                Email = "email@bearstrength.com",
                FullName = "test user"
            };
            var expected = new UserDto
            {
                Username = "username",
                Email = "email@bearstrength.com",
                FullName = "test user"
            };
            var convertedDto = new UserDto
            {
                Username = "username",
                Email = "email@bearstrength.com",
                FullName = "test user"
            };

            mockUserRepository.Setup(repo => repo.AddUser(convertedDto))
                .Returns(convertedDto);

            // act
            var actual = userService.CreateUser(input);

            // assert
            Assert.Equal(expected, actual);
            mockUserRepository.Verify(repo => repo.AddUser(convertedDto), Times.Once);
            mockUserRepository.VerifyNoOtherCalls();
        }
    }
}
