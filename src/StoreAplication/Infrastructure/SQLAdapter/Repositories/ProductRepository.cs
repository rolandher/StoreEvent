using AutoMapper;
using Dapper;
using Domain.Commands.Product;
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

        public async Task<RegisterProduct> CreateProductAsync(Domain.Entities.Products product)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var productToCreate = new Domain.Entities.Products
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductCategory = product.ProductCategory,
                ProductDescription = product.ProductDescription,
                ProductStock = product.ProductStock
            };

            string sqlQuery = $"INSERT INTO {_tableName} ( ProductId, ProductName, ProductPrice, ProductCategory, ProductDescription, ProductStock) VALUES ( @ProductId, @ProductName, @ProductPrice, @ProductCategory, @ProductDescription, @ProductStock)";

            var result = await connection.ExecuteAsync(sqlQuery, productToCreate);
            connection.Close();
            return _mapper.Map<RegisterProduct>(productToCreate);
        }

    }
}
