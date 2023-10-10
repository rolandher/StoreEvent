using Domain.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories.UserRepository;

namespace UseCasesQuery.QuerysUseCase.QueryUserUseCase
{
    public class QUserGetIdUseCase
    {
        private readonly IUserRepository _userRepository;

        public QUserGetIdUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserQueryResponse> GetUserById(Guid UserId)
        {
            return await _userRepository.GetUserByIdAsync(UserId);
        }
    }
}
