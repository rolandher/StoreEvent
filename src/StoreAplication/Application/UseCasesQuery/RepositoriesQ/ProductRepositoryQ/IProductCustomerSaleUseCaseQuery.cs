using Domain.Response.Sale;

namespace UseCasesQuery.RepositoriesQ.ProductRepositoryQ
{
    public interface IProductCustomerSaleUseCaseQuery
    {
        Task<SaleResponse> RegisterProductFinalCustomerSale(string product);
    }
}
