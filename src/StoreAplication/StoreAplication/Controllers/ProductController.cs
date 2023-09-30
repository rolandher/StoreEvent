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

    }

}