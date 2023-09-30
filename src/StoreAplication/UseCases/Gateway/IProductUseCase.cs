using Domain.Commands.Product;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateway
{
    public interface IProductUseCase
    {
        Task<int> RegisterProductAsync(RegisterProductCommand registerProduct);
        Task<string> RegisterProductInventoryAsync(RegisterProductInventoryCommand registerProductInventoryCommand);

        Task<string> RegisterProductSaleAsync(RegisterProductSaleCommand productSaleCommand);
        Task<string> RegisterSaleAsync(RegisterSaleCommand registerSaleCommand);
    }
}
