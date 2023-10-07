using Domain.Entities;

namespace UseCases.Gateway.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> RegisterUserAsync(UserEntity userEntity);
    }
}
