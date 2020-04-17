using BearstrengthEnrollmentApi.Model;
using BearstrengthEnrollmentApi.User.Dto;

namespace BearstrengthEnrollmentApi.User.Service
{
    public interface IUserService
    {
        public UserDto CreateUser(UserRequest userRequest);
    }
}