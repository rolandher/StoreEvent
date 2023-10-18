using AdapterSQL.DTO;
using AutoMapper;
using Domain.Commands.Product;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesProduct;
using Domain.Response.Product;
using Microsoft.EntityFrameworkCore;
using UseCasesCommand.Gateway.Repositories.ProductRepository;

namespace AdapterSQL.SQLAdapter.Repositories
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

            using (var context = new DbConnectionBuilder())
            {
                var productToRegister = new RegisterProductDTO(
                productEntity.Name.Name,
                productEntity.Description.Description,
                productEntity.Price.Price,
                productEntity.InventoryStock.InventoryStock,
                productEntity.Category.Category,
                productEntity.BranchId
                );

                context.Add(productToRegister);
                await context.SaveChangesAsync();

                productEntity.ProductId = productToRegister.ProductId;
                return productEntity;
            }

        }

        public async Task<ProductResponse> RegisterProductInventoryAsync(ProductObjectInventoryStock product, Guid productId)
        {

            using (var context = new DbConnectionBuilder())
            {
                var existingProduct = await context.Product.FindAsync(productId);

                if (existingProduct == null)
                {
                    throw new ArgumentNullException("El producto no se encontro.");
                }

                existingProduct.InvetoryStock += product.InventoryStock;

                await context.SaveChangesAsync();

                return _mapper.Map<ProductResponse>(existingProduct);
            }
        }

        public async Task<ProductResponse> RegisterProductFinalCustomerSaleAsync(RegisterProductSaleCommand command)

        {
            using (var context = new DbConnectionBuilder())
            {
                var existingProduct = await context.Product.FindAsync(command.ProductId);

                if (existingProduct == null)
                {
                    throw new ArgumentNullException("El producto no se encontro.");
                }
                if (existingProduct.InvetoryStock < command.Quantity)
                {
                    throw new Exception($"No hay suficiente stock para el producto: {existingProduct.Name}");
                }
                existingProduct.InvetoryStock -= command.Quantity;

                await context.SaveChangesAsync();

                return _mapper.Map<ProductResponse>(existingProduct);
            }
        }

        public async Task<ProductResponse> RegisterProductResellerSaleAsync(RegisterProductSaleCommand command)
        {
            using (var context = new DbConnectionBuilder())
            {
                var existingProduct = await context.Product.FindAsync(command.ProductId);

                existingProduct.InvetoryStock -= command.Quantity;

                await context.SaveChangesAsync();

                return _mapper.Map<ProductResponse>(existingProduct);
            }
        }

        public async Task<ProductResponse> GetProductByIdAsync(Guid productId)
        {
            var existingProduct = await _dbConnectionBuilder.Product.FindAsync(productId);

            if (existingProduct == null)
            {
                throw new ArgumentNullException("El producto no se encontro.");
            }

            return _mapper.Map<ProductResponse>(existingProduct);
        }
        public async Task<List<ProductResponse>> GetAllProductAsync()
        {
            var products = await _dbConnectionBuilder.Product.ToListAsync();

            var productResponseList = products.Select(product => _mapper.Map<ProductResponse>(product)).ToList();

            return productResponseList;
        }

    }


}
