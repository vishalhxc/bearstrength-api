using System;
using BearstrengthApi.Entity;

namespace BearstrengthApi.Data.Repository
{
    public interface IUserRepository
    {
        void AddUser(UserEntity userEntity);
    }
}
