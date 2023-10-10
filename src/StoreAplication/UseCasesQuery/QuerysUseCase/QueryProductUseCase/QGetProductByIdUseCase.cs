using Domain.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories.ProductRepository;

namespace UseCasesQuery.QuerysUseCase.QueryProductUseCase
{
    public class QGetProductByIdUseCase
    {
        private readonly IProductRepository _repository;

        public QGetProductByIdUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponse> GetProductById(Guid productId)
        {
            return await _repository.GetProductByIdAsync(productId);
        }
    }
}
