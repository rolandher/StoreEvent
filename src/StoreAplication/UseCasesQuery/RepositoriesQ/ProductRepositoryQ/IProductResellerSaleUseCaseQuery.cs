using Domain.Response.Sale;

namespace UseCasesQuery.RepositoriesQ.ProductRepositoryQ
{
    public interface IProductResellerSaleUseCaseQuery
    {
        Task<SaleResponse> RegisterResellerSale(string product);
    }
}
