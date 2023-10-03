using Domain.Commands.Product;
using Domain.Entities;
using Domain.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
