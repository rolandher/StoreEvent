using Domain.Entities;
using Domain.Response.User;

namespace UseCases.Gateway.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<UserEntity> RegisterUserAsync(UserEntity userEntity);

        Task<UserQueryResponse> GetUserByIdAsync(Guid UserId);

        Task<List<UserQueryResponse>> GetAllUsersAsync();
    }
}
