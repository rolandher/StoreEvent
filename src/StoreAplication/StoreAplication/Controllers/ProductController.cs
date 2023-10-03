using AutoMapper;
using Domain.Commands.Product;
using Domain.Entities;
using Domain.Response.Product;
using Microsoft.AspNetCore.Mvc;
using UseCases.Gateway;
using UseCases.UseCases;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StoreAplication.Controllers
{
    [Route("api/v1/product/register")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductUseCase _productUseCase;
        
        public ProductController(IProductUseCase productUseCase)
        {
            _productUseCase = productUseCase;
            
        }

        [HttpPost("register")]
        public async Task<RegisterProductCommand> RegisterProductAsync([FromBody] RegisterProductCommand registerProductCommand)
        {
            return await _productUseCase.RegisterProductAsync(registerProductCommand);
        }

        [HttpPost("api/v1/product/purchase")]
        public async Task<ProductResponse> RegisterProductInventoryAsync(Guid productId, [FromBody] RegisterProductInventoryCommand registerProductInventoryCommand)
        {
            return await _productUseCase.RegisterProductInventoryAsync(productId, registerProductInventoryCommand);
        }

        [HttpPatch("api/v1/product/customer-sale")]
        public async Task<ProductResponse> registerFinalCustomerSaleAsync(Guid productId, [FromBody] RegisterProductSaleCommand registerProductSaleCommand)
        {
            return await _productUseCase.registerFinalCustomerSaleAsync(productId, registerProductSaleCommand);
        }

        [HttpPatch("api/v1/product/reseller-sale")]
        public async Task<ProductResponse> registerResellerSaleAsync(Guid productId, [FromBody] RegisterProductSaleCommand registerProductSaleCommand)
        {
            return await _productUseCase.registerResellerSaleAsync(productId, registerProductSaleCommand);
        }

    }

}