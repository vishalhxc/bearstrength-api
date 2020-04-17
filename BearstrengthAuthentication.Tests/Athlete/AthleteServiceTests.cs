using System.Collections.Generic;
using BearstrengthAuthentication.Error;
using BearstrengthAuthentication.Model;
using BearstrengthAuthentication.Athlete.Dto;
using BearstrengthAuthentication.Athlete.Repository;
using BearstrengthAuthentication.Athlete.Service;
using Moq;
using Xunit;

namespace BearstrengthAuthentication.Tests.Service
{
    public class AthleteServiceTests
    {
        private readonly Mock<IAthleteRepository> mockAthleteRepository;
        private readonly AthleteService athleteService;

        public AthleteServiceTests()
        {
            mockAthleteRepository = new Mock<IAthleteRepository>();
            athleteService = new AthleteService(mockAthleteRepository.Object);
        }

        [Fact(DisplayName = "Create athlete, happy path, calls Repository")]
        public void CreateAthlete_CallsRepository()
        {
            var input = new AthleteRequest
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
            var convertedDto = new AthleteDto
            {
                Username = "user1",
                Email = "user1@email.com",
                FullName = "User One"
            };

            mockAthleteRepository.Setup(repo => repo.AddAthlete(convertedDto))
                .Returns(convertedDto);

            // act
            var actual = athleteService.CreateAthlete(input);

            // assert
            Assert.Equal(expected, actual);
            mockAthleteRepository.Verify(repo => repo.AddAthlete(convertedDto), Times.Once);
            mockAthleteRepository.VerifyNoOtherCalls();
        }

        [Fact(DisplayName = "Create athlete, calls Repository, throws exception")]
        public void CreateAthlete_CallsRepositoryAndThrowsException()
        {
            var input = new AthleteRequest
            {
                Username = "user2",
                Email = "user@email.com",
                FullName = "User Two"
            };
            var expected = new ConflictException(
                new List<string>() { ErrorConstants.UsernameAlreadyExists });

            var convertedDto = new AthleteDto
            {
                Username = "user2",
                Email = "user@email.com",
                FullName = "User Two"
            };
            mockAthleteRepository.Setup(repo => repo.AddAthlete(convertedDto))
                .Throws(expected);

            // act
            var actual = Assert.Throws<ConflictException>(
                () => athleteService.CreateAthlete(input)
            );

            // assert
            Assert.Equal(expected.Messages, actual.Messages);
            mockAthleteRepository.Verify(repo => repo.AddAthlete(convertedDto), Times.Once);
            mockAthleteRepository.VerifyNoOtherCalls();
        }
    }
}
