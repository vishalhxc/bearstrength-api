using System;
using System.ComponentModel.DataAnnotations;
using BearstrengthApi.User.Dto;

namespace BearstrengthApi.Model
{
    public class UserRequest
    {
        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserDto dto &&
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
