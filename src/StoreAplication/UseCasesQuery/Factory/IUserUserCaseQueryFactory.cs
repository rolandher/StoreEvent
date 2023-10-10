using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories.UserRepository;

namespace UseCasesQuery.Factory
{
    public interface IUserUserCaseQueryFactory
    {
        IUserRegisterUseCase Create();
    }

}
