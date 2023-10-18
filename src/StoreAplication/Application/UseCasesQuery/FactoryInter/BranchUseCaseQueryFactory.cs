using Microsoft.Extensions.DependencyInjection;
using UseCasesQuery.Factory;
using UseCasesQuery.RepositoriesQ.BranchRepositoryQ;

namespace UseCasesQuery.FactoryInter
{
    public class BranchUseCaseQueryFactory : IBranchUseCaseQueryFactory
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BranchUseCaseQueryFactory(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public IBranchUseCaseQuery Create()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<IBranchUseCaseQuery>();
        }

    }
}
