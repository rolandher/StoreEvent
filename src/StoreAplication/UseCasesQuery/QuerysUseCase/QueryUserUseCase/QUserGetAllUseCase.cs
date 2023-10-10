using Domain.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories.UserRepository;

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
