using BearstrengthApi.Model;

namespace BearstrengthApi.User.Service
{
    public interface IUserService
    {
        public void CreateUser(UserRequest userRequest);
    }
}