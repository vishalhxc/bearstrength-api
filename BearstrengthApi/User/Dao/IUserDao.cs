using BearstrengthApi.User.Dto;

namespace BearstrengthApi.User.Dao
{
    public interface IUserDao
    {
        public void AddUser(UserDto userDto);
    }
}