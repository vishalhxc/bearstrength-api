using System;
using System.Collections.Generic;
using BearstrengthEnrollmentApi.Data;
using BearstrengthEnrollmentApi.Error;
using BearstrengthEnrollmentApi.User.Dto;
using BearstrengthEnrollmentApi.User.Entity;
using BearstrengthEnrollmentApi.User.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BearstrengthEnrollmentApi.Tests.User.Repository
{
    public class UserRepositoryTests : IDisposable
    {
        private readonly EnrollmentDbContext testContext;
        private readonly IUserRepository userRepository;

        public UserRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<EnrollmentDbContext>()
                .UseInMemoryDatabase("bearstrength_in_memory")
                .Options;
            testContext = new EnrollmentDbContext(options);
            userRepository = new UserRepository(testContext);
        }

        [Fact(DisplayName = "Add user, happy path, checks for existing and saves")]
        public void AddUser_CreatesUserAndReturns()
        {
            var input = new UserDto
            {
                Username = "user1",
                Email = "user1@email.com",
                FullName = "User One"
            };
            var expected = new UserDto
            {
                Username = "user1",
                Email = "user1@email.com",
                FullName = "User One"
            };

            // act
            var actual = userRepository.AddUser(input);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "Add user, user already exists, throw conflict")]
        public void AddUser_ThrowsConflictUser()
        {
            var input = new UserDto
            {
                Username = "user2",
                Email = "user2@email.com",
                FullName = "User Two"
            };
            var expected = new ConflictException(
                new List<string>() { ErrorConstants.UsernameAlreadyExists });

            var existingEntity = new UserEntity
            {
                Username = "user2",
                Email = "user2Other@email.com",
                FullName = "User Two Other"
            };

            testContext.Add(existingEntity);
            testContext.SaveChanges();

            // act
            var actual = Assert.Throws<ConflictException>(
                () => userRepository.AddUser(input));

            // assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact(DisplayName = "Add user, user and email already exists, throw conflict")]
        public void AddUser_ThrowsConflictUserAndEmail()
        {
            var input = new UserDto
            {
                Username = "user3",
                Email = "user3@email.com",
                FullName = "User Three"
            };
            var expected = new ConflictException(
                new List<string>() {
                    ErrorConstants.UsernameAlreadyExists,
                    ErrorConstants.EmailAlreadyExists });

            var existingEntity = new UserEntity
            {
                Username = "user3",
                Email = "user3@email.com",
                FullName = "User Three Other"
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