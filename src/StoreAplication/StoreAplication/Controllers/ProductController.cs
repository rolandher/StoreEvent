using Domain.Commands.Product;
using Domain.Response.Product;
using Domain.Response.Sale;
using Microsoft.AspNetCore.Mvc;
using UseCasesCommand.UseCases.ProductCase;

namespace StoreAplication.Controllers
{
    [Route("api/v1/product/register")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductUseCase _productUseCase;
        private readonly InventoryStockUseCase _inventoryStockUseCase;
        private readonly FinalCustomerSaleUseCase _finalCustomerSaleUseCase;
        private readonly ResellerSaleUseCase _resellerSaleUseCase;

        public ProductController(ProductUseCase productUseCase, InventoryStockUseCase inventoryStockUseCase,
            FinalCustomerSaleUseCase finalCustomerSaleUseCase, ResellerSaleUseCase resellerSaleUseCase)
        {
            _productUseCase = productUseCase;
            _inventoryStockUseCase = inventoryStockUseCase;
            _finalCustomerSaleUseCase = finalCustomerSaleUseCase;
            _resellerSaleUseCase = resellerSaleUseCase;
        }

        [HttpPost("register")]
        public async Task<RegisterProductCommand> RegisterProductAsync([FromBody] RegisterProductCommand registerProductCommand)
        {
            return await _productUseCase.RegisterProductAsync(registerProductCommand);
        }

        [HttpPost("purchase")]
        public async Task<ProductResponse> RegisterProductInventoryAsync(Guid productId, [FromBody] RegisterProductInventoryCommand registerProductInventoryCommand)
        {
            return await _inventoryStockUseCase.RegisterProductInventoryAsync(productId, registerProductInventoryCommand);
        }

        [HttpPatch("customer-sale")]
        public async Task<SaleResponse> RegisterFinalCustomerSaleAsync([FromBody] RegisterSaleCommand registerSaleCommand)
        {
            return await _finalCustomerSaleUseCase.RegisterProductFinalCustomerSaleAsync(registerSaleCommand);
        }

        [HttpPatch("reseller-sale")]
        public async Task<SaleResponse> RegisterResellerSaleAsync([FromBody] RegisterSaleCommand registerSaleCommand)
        {
            return await _resellerSaleUseCase.RegisterProductResellerSaleAsync(registerSaleCommand);
        }

    }

}