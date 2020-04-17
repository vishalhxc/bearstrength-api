using System.Collections.Generic;
using System.Linq;
using BearstrengthAuthentication.Data;
using BearstrengthAuthentication.Error;
using BearstrengthAuthentication.Athlete.Dto;
using BearstrengthAuthentication.Athlete.Entity;

namespace BearstrengthAuthentication.Athlete.Repository
{
    public class AthleteRepository : IAthleteRepository
    {
        private readonly AuthenticationDbContext _context;
        public AthleteRepository(AuthenticationDbContext context)
        {
            _context = context;
        }

        public AthleteDto AddAthlete(AthleteDto athleteDto)
        {
            ValidateAthlete(athleteDto.Username, athleteDto.Email);
            return ConvertToDto(
                SaveAthlete(ConvertToEntity(athleteDto)));
        }

        private List<AthleteEntity> GetAthlete(string username, string email)
        {
            return _context.Athletes.Where(
                u => u.Username == username ||
                u.Email == email).ToList();
        }

        private AthleteEntity SaveAthlete(AthleteEntity athleteEntity)
        {
            var entity = _context.Athletes.Add(athleteEntity)
                .Entity;
            _context.SaveChanges();
            return entity;
        }

        private void ValidateAthlete(string username, string email)
        {
            var athletes = GetAthlete(username, email);
            if (!athletes.Any()) return;

            var errorMessages = new List<string>();
            athletes.ForEach(u =>
            {
                if (u.Username == username)
                    errorMessages.Add(ErrorConstants.UsernameAlreadyExists);
                if (u.Email == email)
                    errorMessages.Add(ErrorConstants.EmailAlreadyExists);
            });
            throw new ConflictException(errorMessages);
        }

        private AthleteEntity ConvertToEntity(AthleteDto athleteDto)
        {
            return new AthleteEntity
            {
                Username = athleteDto.Username,
                Email = athleteDto.Email,
                FullName = athleteDto.FullName
            };
        }

        private AthleteDto ConvertToDto(AthleteEntity athleteEntity)
        {
            return new AthleteDto
            {
                Username = athleteEntity.Username,
                Email = athleteEntity.Email,
                FullName = athleteEntity.FullName
            };
        }
    }
}
