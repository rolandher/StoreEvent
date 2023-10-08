using AutoMapper;
using Domain.Commands.Product;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesProduct;
using Domain.Response.Product;
using Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using UseCases.Gateway.Repositories;

namespace Infrastructure.SQLAdapter.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;


        public ProductRepository(DbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;

        }

        public async Task<ProductEntity> RegisterProductAsync(ProductEntity productEntity)
        {

            var productToCreate = new RegisterProductDTO(

                productEntity.Name.Name,
                productEntity.Description.Description,
                productEntity.Price.Price,
                productEntity.InventoryStock.InventoryStock,
                productEntity.Category.Category,
                productEntity.BranchId
            );

            _dbConnectionBuilder.Add(productToCreate);
            await _dbConnectionBuilder.SaveChangesAsync();

            productEntity.ProductId = productEntity.ProductId;
            return productEntity;

        }

        public async Task<ProductResponse> RegisterProductInventoryAsync(ProductObjectInventoryStock product, Guid productId)
        {

            var existingProduct = await _dbConnectionBuilder.Product.FindAsync(productId);

            if (existingProduct == null)
            {
                throw new ArgumentNullException("El producto no se encontro.");
            }

            existingProduct.InvetoryStock += product.InventoryStock;

            await _dbConnectionBuilder.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(existingProduct);
        }

        public async Task<ProductResponse> RegisterProductFinalCustomerSaleAsync(RegisterProductSaleCommand registerSaleCommand)

        {
            var existingProduct = await _dbConnectionBuilder.Product.FindAsync(registerSaleCommand.ProductId);

            if (existingProduct == null)
            {
                throw new ArgumentNullException("El producto no se encontro.");
            }
            if (existingProduct.InvetoryStock < registerSaleCommand.Quantity)
            {
                throw new Exception($"No hay suficiente stock para el producto: {existingProduct.Name}");
            }
            existingProduct.InvetoryStock -= registerSaleCommand.Quantity;

            await _dbConnectionBuilder.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(existingProduct);
        }

        public async Task<ProductResponse> RegisterProductResellerSaleAsync(RegisterProductSaleCommand registerSale )
        {
            var existingProduct = await _dbConnectionBuilder.Product.FindAsync(registerSale.ProductId);

            if (existingProduct == null)
            {
                throw new ArgumentNullException("El producto no se encontro.");
            }
            if (existingProduct.InvetoryStock < registerSale.Quantity)
            {
                throw new Exception($"No hay suficiente stock para el producto: {existingProduct.Name}");
            }

            existingProduct.InvetoryStock -= registerSale.Quantity;

            await _dbConnectionBuilder.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(existingProduct);
        }

        public async Task<ProductResponse> GetProductById(Guid productId)
        {
            var existingProduct = await _dbConnectionBuilder.Product.FindAsync(productId);

            if (existingProduct == null)
            {
                throw new ArgumentNullException("El producto no se encontro.");
            }

            return _mapper.Map<ProductResponse>(existingProduct);
        }
      
    }


}
