using Domain.Response.Product;

namespace UseCasesQuery.RepositoriesQ.ProductRepositoryQ
{
    public interface IProductInventoryStockUseCaseQuery
    {
        Task<ProductResponse> RegisterProductInventoryStock(string product);
    }
}
