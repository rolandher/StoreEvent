using Domain.Response.Product;
using Microsoft.AspNetCore.Mvc;
using UseCasesQuery.QuerysUseCase.QueryProductUseCase;

namespace StoreApiQuery.Controllers.ProductQuery
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductQueryController : ControllerBase
    {
        private readonly QGetAllProductsUseCase _getAllProductsUseCase;
        private readonly QGetProductByIdUseCase _getProductByIdUseCase;

        public ProductQueryController(QGetAllProductsUseCase getAllProductsUseCase, QGetProductByIdUseCase getProductByIdUseCase)
        {
            _getAllProductsUseCase = getAllProductsUseCase;
            _getProductByIdUseCase = getProductByIdUseCase;
        }

        [HttpGet("GetProductById")]
        public async Task<ProductResponse> GetProductById(Guid productId)
        {
            return await _getProductByIdUseCase.GetProductById(productId);
        }

        [HttpGet("GetAllProducts")]
        public async Task<List<ProductResponse>> GetAllProducts()
        {
            return await _getAllProductsUseCase.GetAllProducts();
        }
    }
}
