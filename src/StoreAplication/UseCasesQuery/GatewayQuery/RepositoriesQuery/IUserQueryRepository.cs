using Domain.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCasesQuery.GatewayQuery.RepositoriesQuery
{
    public interface IUserQueryRepository
    {
         Task<IEnumerable<UserResponse>> GetAllUsersAsync();
    }
}
