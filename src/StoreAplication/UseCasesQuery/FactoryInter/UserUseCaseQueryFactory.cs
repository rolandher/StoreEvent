
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories.UserRepository;
using UseCasesQuery.Factory;

namespace UseCasesQuery.FactoryInter
{
    public class UserUseCaseQueryFactory : IUserUserCaseQueryFactory
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UserUseCaseQueryFactory(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public IUserRegisterUseCase Create()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<IUserRegisterUseCase>();
        }

       
    }
}
