using AutoMapper;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesProduct;
using Domain.Response.Product;
using Infrastructure.DTO;
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

        public async Task<ProductResponse> RegisterProductFinalCustomerSaleAsync(ProductObjectInventoryStock product, Guid productId)

        {
            var existingProduct = await _dbConnectionBuilder.Product.FindAsync(productId);

            if (existingProduct == null)
            {
                throw new ArgumentNullException("El producto no se encontro.");
            }

            existingProduct.InvetoryStock -= product.InventoryStock;

            await _dbConnectionBuilder.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(existingProduct);
        }

        public async Task<ProductResponse> RegisterProductResellerSaleAsync(ProductObjectInventoryStock product, Guid productId)
        {
            var existingProduct = await _dbConnectionBuilder.Product.FindAsync(productId);

            if (existingProduct == null)
            {
                throw new ArgumentNullException("El producto no se encontro.");
            }

            existingProduct.InvetoryStock -= product.InventoryStock;

            await _dbConnectionBuilder.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(existingProduct);
        }

    }


}
