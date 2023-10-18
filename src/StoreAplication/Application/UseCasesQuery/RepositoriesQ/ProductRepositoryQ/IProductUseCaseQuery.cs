using Domain.Response.Product;

namespace UseCasesQuery.RepositoriesQ.ProductRepositoryQ
{
    public interface IProductUseCaseQuery
    {
        Task<ProductResponse> RegisterProduct(string product);
    }
}
