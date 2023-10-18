
using Microsoft.Extensions.DependencyInjection;
using UseCasesQuery.Factory;
using UseCasesQuery.RepositoriesQ.UserRepositoryQ;

namespace UseCasesQuery.FactoryInter
{
    public class UserUseCaseQueryFactory : IUserUserCaseQueryFactory
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UserUseCaseQueryFactory(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public IUserRegisterUseCaseQuery Create()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<IUserRegisterUseCaseQuery>();
        }


    }
}
