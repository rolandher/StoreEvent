using Domain.Response.User;

namespace UseCasesQuery.RepositoriesQ.UserRepositoryQ
{
    public interface IUserRegisterUseCaseQuery
    {
        Task<UserResponse> RegisterUserAsync(string user);
    }
}
