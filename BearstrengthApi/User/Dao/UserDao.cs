using BearstrengthApi.User.Dto;
using BearstrengthApi.User.Entity;
using BearstrengthApi.User.Repository;

namespace BearstrengthApi.User.Dao
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
