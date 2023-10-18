using Domain.Response.Product;
using UseCasesCommand.Gateway.Repositories.ProductRepository;

namespace UseCasesQuery.QuerysUseCase.QueryProductUseCase
{
    public class QGetAllProductsUseCase
    {
        private readonly IProductRepository _repository;

        public QGetAllProductsUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            return await _repository.GetAllProductAsync();
        }
    }
}
