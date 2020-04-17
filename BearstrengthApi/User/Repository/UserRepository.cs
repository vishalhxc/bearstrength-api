using BearstrengthApi.Data;
using BearstrengthApi.Error;
using BearstrengthApi.User.Dto;
using BearstrengthApi.User.Entity;

namespace BearstrengthApi.User.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BearstrengthDbContext _context;
        public UserRepository(BearstrengthDbContext context)
        {
            _context = context;
        }

        public UserDto AddUser(UserDto userDto)
        {
            if (GetUser(userDto.Username) != null)
            {
                throw new ConflictException(
                    ErrorConstants.UsernameAlreadyExists);
            }

            var entity = _context.Users.Add(ConvertToEntity(userDto))
                .Entity;
            _context.SaveChanges();
            return ConvertToDto(entity);
        }

        private UserEntity GetUser(string username)
        {
            return _context.Users.Find(username);
        }

        private UserEntity ConvertToEntity(UserDto userDto)
        {
            return new UserEntity
            {
                Username = userDto.Username,
                Email = userDto.Email,
                FullName = userDto.FullName
            };
        }

        private UserDto ConvertToDto(UserEntity userEntity)
        {
            return new UserDto
            {
                Username = userEntity.Username,
                Email = userEntity.Email,
                FullName = userEntity.FullName
            };
        }
    }
}
