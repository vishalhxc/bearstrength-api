using BearstrengthApi.Model;
using BearstrengthApi.User.Dto;

namespace BearstrengthApi.User.Service
{
    public interface IUserService
    {
        public UserDto CreateUser(UserRequest userRequest);
    }
}