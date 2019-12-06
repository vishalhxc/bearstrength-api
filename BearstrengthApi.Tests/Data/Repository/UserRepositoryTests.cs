using System;
using BearstrengthApi.Data.Repository;
using BearstrengthApi.Entity;
using Moq;
using Xunit;

namespace BearstrengthApi.Tests.Data.Repository
{
    public class UserRepositoryTests
    {
        private const string Username = "username";
        private const string Email = "email";
        private const string FullName = "fullName";


        private readonly Mock<BearstrengthDbContext> mockDbContext;
        private readonly IUserRepository userRepository;
        private UserEntity userEntity;

        public UserRepositoryTests()
        {
            mockDbContext = new Mock<BearstrengthDbContext>();
            userRepository = new UserRepository(mockDbContext.Object);
            userEntity = new UserEntity
            {
                Username = Username,
                Email = Email,
                FullName = FullName
            };
        }

        [Fact(DisplayName = "Add user calls context")]
        public void AddUser_CreatesUser()
        {
            userRepository.AddUser(userEntity);

            mockDbContext.Verify(context => context.Users.Add(userEntity));
            mockDbContext.Verify(context => context.SaveChanges());
        }
    }
}
