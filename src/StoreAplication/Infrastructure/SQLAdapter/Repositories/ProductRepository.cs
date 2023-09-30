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
                productEntity.Category.ToString(),
                productEntity.BranchId);                
    
                _dbConnectionBuilder.Add(productToCreate);
                await _dbConnectionBuilder.SaveChangesAsync();
    
                return productToCreate.Id;            
        }

        public async Task<string> RegisterProductInventoryAsync(RegisterProductInventoryCommand registerProductInventoryCommand)
        {
            var productInventoryToCreate = new RegisterProductInventoryStockDTO(
                               registerProductInventoryCommand.Id,
                               registerProductInventoryCommand.Quantity);

            _dbConnectionBuilder.Add(productInventoryToCreate);
            await _dbConnectionBuilder.SaveChangesAsync();

            return productInventoryToCreate.Id;
            
        }

        public async Task<string> RegisterProductSaleAsync(RegisterProductSaleCommand productSaleCommand)
        {
            var productSaleToCreate = new RegisterProductSaleDTO(
                                      productSaleCommand.Id,
                                      productSaleCommand.Quantity);

            _dbConnectionBuilder.Add(productSaleToCreate);
            await _dbConnectionBuilder.SaveChangesAsync();

            return productSaleToCreate.Id;
        }

        public async Task<string> RegisterSaleAsync(RegisterSaleCommand registerSaleCommand)
        {
            var saleToCreate = new RegisterSaleDTO(
                                 registerSaleCommand.Products);

            _dbConnectionBuilder.Add(saleToCreate);
            await _dbConnectionBuilder.SaveChangesAsync();

            return saleToCreate.Id;                                   

            
        }
    }
}
