using UseCasesQuery.RepositoriesQ.ProductRepositoryQ;

namespace UseCasesQuery.Factory
{
    public interface IProductUseCaseQueryFactory
    {
        IProductUseCaseQuery Create();
        IProductCustomerSaleUseCaseQuery RegisterCustomerSale();
        IProductResellerSaleUseCaseQuery RegisterResellerSale();
        IProductInventoryStockUseCaseQuery RegisterProductStock();

    }
}
