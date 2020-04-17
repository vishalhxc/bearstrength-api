using System;
using System.Collections.Generic;
using BearstrengthAuthentication.Data;
using BearstrengthAuthentication.Error;
using BearstrengthAuthentication.Athlete.Dto;
using BearstrengthAuthentication.Athlete.Entity;
using BearstrengthAuthentication.Athlete.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BearstrengthAuthentication.Tests.Athlete.Repository
{
    public class AthleteRepositoryTests : IDisposable
    {
        private readonly AuthenticationDbContext testContext;
        private readonly IAthleteRepository athleteRepository;

        public AthleteRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AuthenticationDbContext>()
                .UseInMemoryDatabase("bearstrength_in_memory")
                .Options;
            testContext = new AuthenticationDbContext(options);
            athleteRepository = new AthleteRepository(testContext);
        }

        [Fact(DisplayName = "Add athlete, happy path, checks for existing and saves")]
        public void AddAthlete_CreatesAthleteAndReturns()
        {
            var input = new AthleteDto
            {
                Username = "user1",
                Email = "user1@email.com",
                FullName = "User One"
            };
            var expected = new AthleteDto
            {
                Username = "user1",
                Email = "user1@email.com",
                FullName = "User One"
            };

            // act
            var actual = athleteRepository.AddAthlete(input);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "Add athlete, athlete already exists, throw conflict")]
        public void AddAthlete_ThrowsConflictAthlete()
        {
            var input = new AthleteDto
            {
                Username = "user2",
                Email = "user2@email.com",
                FullName = "User Two"
            };
            var expected = new ConflictException(
                new List<string>() { ErrorConstants.UsernameAlreadyExists });

            var existingEntity = new AthleteEntity
            {
                Username = "user2",
                Email = "user2Other@email.com",
                FullName = "User Two Other"
            };

            testContext.Add(existingEntity);
            testContext.SaveChanges();

            // act
            var actual = Assert.Throws<ConflictException>(
                () => athleteRepository.AddAthlete(input));

            // assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact(DisplayName = "Add athlete, user and email already exists, throw conflict")]
        public void AddAthlete_ThrowsConflictAthleteAndEmail()
        {
            var input = new AthleteDto
            {
                Username = "user3",
                Email = "user3@email.com",
                FullName = "User Three"
            };
            var expected = new ConflictException(
                new List<string>() {
                    ErrorConstants.UsernameAlreadyExists,
                    ErrorConstants.EmailAlreadyExists });

            var existingEntity = new AthleteEntity
            {
                Username = "user3",
                Email = "user3@email.com",
                FullName = "User Three Other"
            };

            testContext.Add(existingEntity);
            testContext.SaveChanges();

            // act
            var actual = Assert.Throws<ConflictException>(
                () => athleteRepository.AddAthlete(input));

            // assert
            Assert.Equal(expected.Message, actual.Message);
        }

        public void Dispose()
        {
            testContext.Dispose();
        }
    }
}