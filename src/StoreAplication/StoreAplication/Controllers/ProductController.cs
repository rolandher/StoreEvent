using Domain.Commands.Product;
using Domain.Commands.Sales;
using Domain.Response.Product;
using Domain.Response.Sale;
using Microsoft.AspNetCore.Mvc;
using UseCases.Gateway;
using UseCases.UseCases;

namespace StoreAplication.Controllers
{
    [Route("api/v1/product/register")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductUseCase _productUseCase;

        public ProductController(ProductUseCase productUseCase)
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
        public async Task<SaleResponse> RegisterFinalCustomerSaleAsync([FromBody] RegisterSaleCommand registerSaleCommand)
        {
            return await _productUseCase.RegisterProductFinalCustomerSaleAsync(registerSaleCommand);
        }

        [HttpPatch("api/v1/product/reseller-sale")]
        public async Task<SaleResponse> RegisterResellerSaleAsync([FromBody] RegisterSaleCommand registerSaleCommand)
        {
            return await _productUseCase.RegisterProductResellerSaleAsync(registerSaleCommand);
        }

    }

}