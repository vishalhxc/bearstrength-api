using BearstrengthApi.Model;
using BearstrengthApi.User.Dao;
using BearstrengthApi.User.Dto;

namespace BearstrengthApi.User.Service
{
    public class UserService : IUserService
    {
        private readonly IUserDao _userDao;

        public UserService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public void CreateUser(UserRequest userRequest)
        {
            _userDao.AddUser(ConvertRequestToDto(userRequest));
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