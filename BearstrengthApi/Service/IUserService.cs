using System;
using BearstrengthApi.DTO;

namespace BearstrengthApi.Service
{
    public interface IUserService
    {
        public void CreateUser(UserDto userDto);
    }
}
