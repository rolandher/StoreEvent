using Domain.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories;
using UseCasesQuery.GatewayQuery;
using UseCasesQuery.GatewayQuery.RepositoriesQuery;

namespace UseCasesQuery.QueryUseCase
{
    public class QUserUseCase 
    {

        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IStoredEventRepository _storedEvent;
        public QUserUseCase(IUserQueryRepository userQueryRepository, IStoredEventRepository storedEvent)
        {
            _userQueryRepository = userQueryRepository;
            _storedEvent = storedEvent;
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            var users = await _userQueryRepository.GetAllUsersAsync();
            return users;
        }

    }
}
