using System;
using BearstrengthAuthentication.Athlete.Dto;

namespace BearstrengthAuthentication.Model
{
    public class AthleteResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AthleteResponse dto &&
                   Username == dto.Username &&
                   Email == dto.Email &&
                   FullName == dto.FullName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Email, FullName);
        }
    }
}
