using Domain.Commands.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories;
using UseCases.Gateway;
using Domain.Commands.Product;

namespace UseCases.UseCases
{
    public class ProductUseCase : IProductUseCase
    {
        private readonly IProductRepository _productRepository;
        public ProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<RegisterProduct> CreateProductAsync(Products product)
        {
            return await _productRepository.CreateProductAsync(product);
        }
        
    }
}
