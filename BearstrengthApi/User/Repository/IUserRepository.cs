using BearstrengthApi.User.Entity;

namespace BearstrengthApi.User.Repository
{
    public interface IUserRepository
    {
        void AddUser(UserEntity userEntity);
    }
}
