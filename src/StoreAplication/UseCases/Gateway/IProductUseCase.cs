using Domain.Commands.Product;
using Domain.Response.Product;

namespace UseCases.Gateway
{
    public interface IProductUseCase
    {
        Task<RegisterProductCommand> RegisterProductAsync(RegisterProductCommand registerProductCommand);
        Task<ProductResponse> RegisterProductInventoryAsync(Guid productId, RegisterProductInventoryCommand registerProductInventoryCommand);

        Task<ProductResponse> registerFinalCustomerSaleAsync(Guid productId, RegisterProductSaleCommand registerProductSaleCommand);
        Task<ProductResponse> registerResellerSaleAsync(Guid productId, RegisterProductSaleCommand registerProductSaleCommand);
    }
}
