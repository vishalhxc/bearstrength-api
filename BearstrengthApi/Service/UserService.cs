using System;
using BearstrengthApi.DAO;
using BearstrengthApi.DTO;

namespace BearstrengthApi.Service
{
    public class UserService : IUserService
    {
        private readonly IUserDao _userDao;

        public UserService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public void CreateUser(UserDto userDto)
        {
            _userDao.AddUser(userDto);
        }
    }
}
