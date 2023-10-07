using Domain.Entities;
using Domain.ObjectValues;
using Domain.ObjectValues.ObjectValuesUser;
using Infrastructure.DTO;
using UseCases.Gateway.Repositories;

namespace Infrastructure.SQLAdapter.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnectionBuilder _dbConnectionBuilder;

        public UserRepository(DbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;

        }

        public async Task<UserEntity> RegisterUserAsync(UserEntity userEntity)
        {

            var userToCreate = new RegisterUserDTO(

                $"{userEntity.Name.Name} {userEntity.Name.LastName}",
                userEntity.Password.Password,
                userEntity.Email.Email,
                userEntity.Role.Role,
                userEntity.BranchId);

            _dbConnectionBuilder.Add(userToCreate);
            await _dbConnectionBuilder.SaveChangesAsync();

            userEntity.UserId = userToCreate.UserId;

            return userEntity;

        }

        public async Task<UserEntity> GetUserByIdAsync(Guid userId)
        {
            var user = await _dbConnectionBuilder.Users.FirstOrDefaultAsync(x => x.UserId == userId);

            if (user == null)
            {
                return null;
            }

            var userEntity = new UserEntity(
                new UserObjectName(user.Name, user.LastName),
                new UserObjectPassword(user.Password),
                new UserObjectEmail(user.Email),
                new UserObjectRole(user.Role),
                user.BranchId
            );

            userEntity.UserId = user.UserId;

            return userEntity;
        }
    }
}


