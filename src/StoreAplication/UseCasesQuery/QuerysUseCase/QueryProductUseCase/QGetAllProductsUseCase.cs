using Domain.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories.ProductRepository;

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
