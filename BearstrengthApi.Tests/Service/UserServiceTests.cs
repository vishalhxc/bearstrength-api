using BearstrengthApi.DAO;
using BearstrengthApi.DTO;
using BearstrengthApi.Entity;
using BearstrengthApi.Service;
using Moq;
using Xunit;

namespace BearstrengthApi.Tests.Service
{
    public class UserServiceTests
    {
        private const string Id = "id";
        private const string Username = "username";
        private const string Email = "email";
        private const string FullName = "fullName";

        private Mock<IUserDao> mockUserDao;
        private UserService userService;
        private UserDto userDto;

        public UserServiceTests()
        {
            mockUserDao = new Mock<IUserDao>();

            userService = new UserService(mockUserDao.Object);

            userDto = new UserDto
            {
                Username = Username,
                Email = Email,
                FullName = FullName
            };
        }

        [Fact(DisplayName = "Create user calls DAO")]
        public void CreateUser_CallsRepository()
        {
            mockUserDao.Setup(
                dao => dao.AddUser(It.IsAny<UserDto>())).Verifiable();

            userService.CreateUser(userDto);

            mockUserDao.Verify(dao => dao.AddUser(userDto), Times.Once);
        }
    }
}
