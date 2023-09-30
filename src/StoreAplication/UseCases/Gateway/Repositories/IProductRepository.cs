using Domain.Commands.Product;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateway.Repositories
{
    public interface IProductRepository
    {
        Task<int> RegisterProductAsync(ProductEntity productEntity);

        Task<string> RegisterProductInventoryAsync(RegisterProductInventoryCommand registerProductInventoryCommand);

        Task<string> RegisterProductSaleAsync(RegisterProductSaleCommand productSaleCommand);

        Task<string> RegisterSaleAsync(RegisterSaleCommand registerSaleCommand);
    }
}
