using System;
using System.Collections.Generic;
using BearstrengthApi.Data;
using BearstrengthApi.Error;
using BearstrengthApi.User.Dto;
using BearstrengthApi.User.Entity;
using BearstrengthApi.User.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BearstrengthApi.Tests.User.Repository
{
    public class UserRepositoryTests : IDisposable
    {
        private readonly BearstrengthDbContext testContext;
        private readonly IUserRepository userRepository;

        public UserRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<BearstrengthDbContext>()
                .UseInMemoryDatabase("bearstrength_in_memory")
                .Options;
            testContext = new BearstrengthDbContext(options);
            userRepository = new UserRepository(testContext);
        }

        [Fact(DisplayName = "Add user, happy path, checks for existing and saves")]
        public void AddUser_CreatesUserAndReturns()
        {
            var input = new UserDto
            {
                Username = "username",
                Email = "username@bearstrength.com",
                FullName = "test user"
            };
            var expected = new UserDto
            {
                Username = "username",
                Email = "username@bearstrength.com",
                FullName = "test user"
            };
            var convertedEntity = new UserEntity
            {
                Username = "username",
                Email = "username@bearstrength.com",
                FullName = "test user"
            };

            // act
            var actual = userRepository.AddUser(input);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "Add user, user already exists, throw conflict")]
        public void AddUser_ThrowsConflict()
        {
            var input = new UserDto
            {
                Username = "existinguser",
                Email = "anotheruser@bearstrength.com",
                FullName = "test user"
            };
            var expected = new ConflictException(
                new List<string>() { ErrorConstants.UsernameAlreadyExists });

            var existingEntity = new UserEntity
            {
                Username = "existinguser",
                Email = "existinguser@bearstrength.com",
                FullName = "test user"
            };

            testContext.Add(existingEntity);
            testContext.SaveChanges();

            // act
            var actual = Assert.Throws<ConflictException>(
                () => userRepository.AddUser(input));

            // assert
            Assert.Equal(expected.Message, actual.Message);
        }

        public void Dispose()
        {
            testContext.Dispose();
        }
    }
}