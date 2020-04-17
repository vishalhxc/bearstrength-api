using BearstrengthAuthentication.Model;
using BearstrengthAuthentication.Athlete.Dto;
using BearstrengthAuthentication.Athlete.Repository;

namespace BearstrengthAuthentication.Athlete.Service
{
    public class AthleteService : IAthleteService
    {
        private readonly IAthleteRepository _athleteRepository;

        public AthleteService(IAthleteRepository athleteRepository)
        {
            _athleteRepository = athleteRepository;
        }

        public AthleteDto CreateAthlete(AthleteRequest athleteRequest)
        {
            return _athleteRepository.AddAthlete(ConvertRequestToDto(athleteRequest));
        }

        private AthleteDto ConvertRequestToDto(AthleteRequest athleteRequest)
        {
            return new AthleteDto
            {
                Username = athleteRequest.Username,
                Email = athleteRequest.Email,
                FullName = athleteRequest.FullName
            };
        }
    }
}