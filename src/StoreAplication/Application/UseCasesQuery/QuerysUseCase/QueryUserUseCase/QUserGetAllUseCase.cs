using Domain.Response.User;
using UseCasesCommand.Gateway.Repositories.UserRepository;

namespace UseCasesQuery.QuerysUseCase.QueryUserUseCase
{
    public class QUserGetAllUseCase
    {
        private readonly IUserRepository _userRepository;

        public QUserGetAllUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserQueryResponse>> GetAllUsers()
        {
            return await _userRepository.GetAllUsersAsync();
        }
    }
}
