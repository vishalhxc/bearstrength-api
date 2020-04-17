using BearstrengthApi.User.Dto;

namespace BearstrengthApi.User.Repository
{
    public interface IUserRepository
    {
        UserDto AddUser(UserDto userDto);
    }
}
