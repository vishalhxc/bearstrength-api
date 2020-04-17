using BearstrengthAuthentication.Athlete.Dto;

namespace BearstrengthAuthentication.Athlete.Repository
{
    public interface IAthleteRepository
    {
        AthleteDto AddAthlete(AthleteDto athleteDto);
    }
}
