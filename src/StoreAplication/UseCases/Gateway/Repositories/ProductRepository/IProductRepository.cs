using Domain.Commands.Product;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesProduct;
using Domain.Response.Product;
using Domain.Response.Sale;

namespace UseCases.Gateway.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<ProductEntity> RegisterProductAsync(ProductEntity productEntity);

        Task<ProductResponse> RegisterProductInventoryAsync(ProductObjectInventoryStock product, Guid productId);

        Task<ProductResponse> RegisterProductFinalCustomerSaleAsync(RegisterProductSaleCommand registersalecommand);

        Task<ProductResponse> RegisterProductResellerSaleAsync(RegisterProductSaleCommand registersalecommand);

        Task <ProductResponse> GetProductByIdAsync(Guid productId);

        Task<List<ProductResponse>> GetAllProductAsync();

    }
}
