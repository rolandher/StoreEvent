using AutoMapper;
using Dapper;
using Domain.Commands.Product;
using Domain.Entities;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories;

namespace Infrastructure.SQLAdapter.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbConnectionBuilder _dbConnectionBuilder;
        

        public ProductRepository(DbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            
        }

        public async Task<int> RegisterProductAsync(ProductEntity productEntity)
        {
            var productToCreate = new RegisterProductDTO(

                productEntity.Name.Name,
                productEntity.Description.Description,
                productEntity.Price.Price,
                productEntity.Category,
                productEntity.BranchId);                
    
                _dbConnectionBuilder.Add(productToCreate);
                await _dbConnectionBuilder.SaveChangesAsync();
    
                return productToCreate.ProductId;            
        }
    }
}
