using Microsoft.Extensions.DependencyInjection;
using UseCasesQuery.Factory;
using UseCasesQuery.RepositoriesQ.ProductRepositoryQ;

namespace UseCasesQuery.FactoryInter
{
    public class ProductUseCaseQueryFactory : IProductUseCaseQueryFactory
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ProductUseCaseQueryFactory(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public IProductUseCaseQuery Create()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<IProductUseCaseQuery>();
        }

        public IProductCustomerSaleUseCaseQuery RegisterCustomerSale()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<IProductCustomerSaleUseCaseQuery>();
        }

        public IProductResellerSaleUseCaseQuery RegisterResellerSale()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<IProductResellerSaleUseCaseQuery>();
        }

        public IProductInventoryStockUseCaseQuery RegisterProductStock()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<IProductInventoryStockUseCaseQuery>();
        }
    }
}
