using AutoMapper;
using Domain.Commands.Product;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using UseCases.Gateway;
using UseCases.UseCases;

namespace StoreAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductUseCase _productUseCase;
        private readonly IMapper _mapper;

        public ProductController(IProductUseCase productUseCase, IMapper mapper)
        {
            _productUseCase = productUseCase;
            _mapper = mapper;
        }

        [HttpPost]

        public async Task<RegisterProduct> CreateProductAsync([FromBody] RegisterProduct registerProduct)
        {
            return await _productUseCase.CreateProductAsync(_mapper.Map<Products>(registerProduct));
        }

    }

}