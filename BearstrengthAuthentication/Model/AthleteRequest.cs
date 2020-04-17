using System;
using System.ComponentModel.DataAnnotations;
using BearstrengthAuthentication.Error;
using BearstrengthAuthentication.Athlete.Dto;

namespace BearstrengthAuthentication.Model
{
    public class AthleteRequest
    {
        [Required(ErrorMessage = ErrorConstants.UsernameIsRequired)]
        [StringLength(20, ErrorMessage = ErrorConstants.UsernameTooLong)]
        public string Username { get; set; }

        [Required(ErrorMessage = ErrorConstants.EmailIsRequired)]
        [StringLength(100, ErrorMessage = ErrorConstants.EmailTooLong)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorConstants.FullNameIsRequired)]
        [StringLength(100, ErrorMessage = ErrorConstants.FullNameTooLong)]
        public string FullName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AthleteDto dto &&
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
