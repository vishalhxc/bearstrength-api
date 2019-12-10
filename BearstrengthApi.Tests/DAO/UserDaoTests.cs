using System;
using BearstrengthApi.DAO;
using BearstrengthApi.Data.Repository;
using BearstrengthApi.DTO;
using BearstrengthApi.Entity;
using Moq;
using Xunit;

namespace BearstrengthApi.Tests.DAO
{
    public class UserDaoTests
    {
        private const string Username = "username";
        private const string Email = "email";
        private const string FullName = "fullName";

        private Mock<IUserRepository> mockRepository;
        private UserDao userDao;
        private UserDto userDto;
        private UserEntity userEntity;

        public UserDaoTests()
        {
            mockRepository = new Mock<IUserRepository>();

            userDao = new UserDao(mockRepository.Object);

            userDto = new UserDto
            {
                Username = Username,
                Email = Email,
                FullName = FullName
            };

            userEntity = new UserEntity
            {
                Username = Username,
                Email = Email,
                FullName = FullName
            };
        }

        [Fact(DisplayName = "Add user calls repository")]
        public void AddUser_CallsRepository()
        {
            mockRepository.Setup(
                repo => repo.AddUser(It.IsAny<UserEntity>())).Verifiable();

            userDao.AddUser(userDto);

            mockRepository.Verify(repo => repo.AddUser(userEntity), Times.Once);
        }
    }
}
