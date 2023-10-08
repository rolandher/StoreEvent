using Domain.Commands.Product;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesProduct;
using Domain.Response.Product;

namespace UseCases.Gateway.Repositories
{
    public interface IProductRepository
    {
        Task<ProductEntity> RegisterProductAsync(ProductEntity productEntity);

        Task<ProductResponse> RegisterProductInventoryAsync(ProductObjectInventoryStock product, Guid productId);

        Task<ProductResponse> RegisterProductFinalCustomerSaleAsync(RegisterProductSaleCommand registerSaleCommand);

        Task<ProductResponse> RegisterProductResellerSaleAsync(RegisterProductSaleCommand registerSale);

        Task<ProductResponse> GetProductById(Guid productId);

    }
}
