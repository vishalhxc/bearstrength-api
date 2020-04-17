using BearstrengthEnrollmentApi.User.Dto;

namespace BearstrengthEnrollmentApi.User.Repository
{
    public interface IUserRepository
    {
        UserDto AddUser(UserDto userDto);
    }
}
