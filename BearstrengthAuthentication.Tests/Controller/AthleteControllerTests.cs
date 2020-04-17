using BearstrengthAuthentication.Controller;
using BearstrengthAuthentication.Model;
using BearstrengthAuthentication.Athlete.Dto;
using BearstrengthAuthentication.Athlete.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BearstrengthAuthentication.Tests.Controller
{
    public class AthleteControllerTests
    {
        private readonly Mock<IAthleteService> mockAthleteService;
        private readonly AthleteController athleteController;

        public AthleteControllerTests()
        {
            mockAthleteService = new Mock<IAthleteService>();
            athleteController = new AthleteController(mockAthleteService.Object);
        }

        [Fact(DisplayName = "Create athlete, happy path, endpoint calls athlete service and returns response")]
        public void CreateAthlete_CallsRepository()
        {
            var input = new AthleteRequest
            {
                Username = "user1",
                Email = "user1@email.com",
                FullName = "User One"
            };
            var expectedStatus = 201;
            var expected = new DetailResponse<AthleteResponse>
            {
                Status = 201,
                Detail = new AthleteResponse
                {
                    Username = "user1",
                    Email = "user1@email.com",
                    FullName = "User One"
                }
            };
            var convertedDto = new AthleteDto
            {
                Username = "user1",
                Email = "user1@email.com",
                FullName = "User One"
            };

            mockAthleteService.Setup(service => service.CreateAthlete(input))
                .Returns(convertedDto);

            // act
            var actual = athleteController.CreateAthlete(input).Result
                as CreatedResult;

            // assert
            Assert.Equal(expected, actual.Value);
            Assert.Equal(expectedStatus, actual.StatusCode);
            mockAthleteService.Verify(service => service.CreateAthlete(input), Times.Once);
            mockAthleteService.VerifyNoOtherCalls();
        }
    }
}
