using AutoMapper;
using Domain.Commands.Product;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using UseCases.Gateway;
using UseCases.UseCases;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StoreAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductUseCase _productUseCase;
        
        public ProductController(IProductUseCase productUseCase)
        {
            _productUseCase = productUseCase;
            
        }

        [HttpPost]
        public async Task<int> RegisterProductAsync([FromBody] RegisterProductCommand registerProductCommand)
        {
            return await _productUseCase.RegisterProductAsync(registerProductCommand);
        }

        [HttpPost]        
        public async Task<string> RegisterProductInventoryAsync([FromBody] RegisterProductInventoryCommand registerProductInventoryCommand)
        {
            return await _productUseCase.RegisterProductInventoryAsync(registerProductInventoryCommand);
        }
        [HttpPost]        
        public async Task<string> RegisterProductSaleAsync([FromBody] RegisterProductSaleCommand productSaleCommand)
        {
            return await _productUseCase.RegisterProductSaleAsync(productSaleCommand);
        }

        [HttpPost]
        public async Task<string> RegisterSaleAsync([FromBody] RegisterSaleCommand registerSaleCommand)
        {
            return await _productUseCase.RegisterSaleAsync(registerSaleCommand);
        }

    }

}