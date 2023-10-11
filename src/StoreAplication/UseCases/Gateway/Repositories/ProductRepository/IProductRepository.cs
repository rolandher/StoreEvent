using Domain.Commands.Product;
using Domain.Commands.Sales;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesProduct;
using Domain.Response.Product;

namespace UseCases.Gateway.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<ProductEntity> RegisterProductAsync(ProductEntity productEntity);

        Task<ProductResponse> RegisterProductInventoryAsync(ProductObjectInventoryStock product, Guid productId);

        Task<ProductResponse> RegisterProductFinalCustomerSaleAsync(RegisterProductSaleCommand command);

        Task<ProductResponse> RegisterProductResellerSaleAsync(RegisterProductSaleCommand command);

        Task <ProductResponse> GetProductByIdAsync(Guid productId);

        Task<List<ProductResponse>> GetAllProductAsync();

    }
}
