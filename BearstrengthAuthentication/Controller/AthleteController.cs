using BearstrengthAuthentication.Model;
using BearstrengthAuthentication.Athlete.Dto;
using BearstrengthAuthentication.Athlete.Service;
using Microsoft.AspNetCore.Mvc;

namespace BearstrengthAuthentication.Controller
{
    [ApiController]
    [Route("api/athletes")]
    public class AthleteController : ControllerBase
    {
        private readonly IAthleteService _athleteService;

        public AthleteController(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }

        [HttpPost]
        public ActionResult<DetailResponse<AthleteResponse>> CreateAthlete(AthleteRequest athlete)
        {
            var athleteDto = _athleteService.CreateAthlete(athlete);
            return Created("CreateUser",
                new DetailResponse<AthleteResponse>
                {
                    Status = 201,
                    Detail = ConvertToAthleteResponse(athleteDto)
                });
        }

        private AthleteResponse ConvertToAthleteResponse(AthleteDto athleteDto)
        {
            return new AthleteResponse
            {
                Username = athleteDto.Username,
                Email = athleteDto.Email,
                FullName = athleteDto.FullName
            };
        }
    }
}
