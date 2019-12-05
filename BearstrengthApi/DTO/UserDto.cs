using System;
using System.ComponentModel.DataAnnotations;

namespace BearstrengthApi.DTO
{
    public class UserDto
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
    }
}
