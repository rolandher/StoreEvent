using AutoMapper;
using Dapper;
using Domain.Commands.Product;
using Domain.Entities;
using Infrastructure.SQLAdapter.Gateway;
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
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;
        private readonly string _tableName = "Products";

        public ProductRepository(IDbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
        }

        public async Task<RegisterProductCommand> RegisterProductAsync(Products product)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            var productToCreate = new Products
            {                
                ProductName = product.ProductName,
                IdBranch = product.IdBranch,
                ProductPrice = product.ProductPrice,
                ProductInventoryStock = product.ProductInventoryStock,
                ProductDescription = product.ProductDescription,
                ProductCategory = product.ProductCategory
            };

            string sqlQuery = $"INSERT INTO {_tableName} (ProductId, ProductName, ProductPrice, ProductInventoryStock, ProductDescription, ProductCategory) VALUES (@ProductId, @ProductName, @ProductPrice, @ProductInventoryStock, @ProductDescription, @ProductCategory)";

            var result = await connection.ExecuteAsync(sqlQuery, productToCreate);

            connection.Close();

            return _mapper.Map<RegisterProductCommand>(productToCreate);

        }


    }
}
