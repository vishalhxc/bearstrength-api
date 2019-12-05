using System;
using BearstrengthApi.Data.Repository;
using BearstrengthApi.DTO;
using BearstrengthApi.Entity;

namespace BearstrengthApi.DAO
{
    public class UserDao : IUserDao
    {
        private readonly IUserRepository _userRepository;

        public UserDao(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(UserDto userDto)
        {
            _userRepository.AddUser(new UserEntity
            {
                Username = userDto.Username,
                Email = userDto.Email,
                FullName = userDto.FullName
            });
        }
    }
}
