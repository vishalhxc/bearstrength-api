using BearstrengthEnrollmentApi.Model;
using BearstrengthEnrollmentApi.User.Dto;
using BearstrengthEnrollmentApi.User.Repository;

namespace BearstrengthEnrollmentApi.User.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto CreateUser(UserRequest userRequest)
        {
            return _userRepository.AddUser(ConvertRequestToDto(userRequest));
        }

        private UserDto ConvertRequestToDto(UserRequest userRequest)
        {
            return new UserDto
            {
                Username = userRequest.Username,
                Email = userRequest.Email,
                FullName = userRequest.FullName
            };
        }
    }
}