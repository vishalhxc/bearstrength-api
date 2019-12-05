using BearstrengthApi.DTO;

namespace BearstrengthApi.DAO
{
    public interface IUserDao
    {
        public void AddUser(UserDto userDto);
    }
}