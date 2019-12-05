using System;
using BearstrengthApi.DTO;
using BearstrengthApi.Entity;

namespace BearstrengthApi.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BearstrengthDbContext _context;

        public UserRepository(BearstrengthDbContext context)
        {
            _context = context;
        }

        public void AddUser(UserEntity userEntity)
        {
            _context.Users.Add(userEntity);
            _context.SaveChanges();
        }
    }
}
