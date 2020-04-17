using BearstrengthAuthentication.Model;
using BearstrengthAuthentication.Athlete.Dto;

namespace BearstrengthAuthentication.Athlete.Service
{
    public interface IAthleteService
    {
        public AthleteDto CreateAthlete(AthleteRequest athleteRequest);
    }
}