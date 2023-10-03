using Domain.Commands.Product;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesProduct;
using Domain.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateway.Repositories
{
    public interface IProductRepository
    {
        Task<ProductEntity> RegisterProductAsync(ProductEntity productEntity);

        Task<ProductResponse> RegisterProductInventoryAsync(ProductObjectInventoryStock product, Guid productId);

        Task<ProductResponse> RegisterProductFinalCustomerSaleAsync(ProductObjectInventoryStock product, Guid productId);

        Task<ProductResponse> RegisterProductResellerSaleAsync(ProductObjectInventoryStock product, Guid productId);

    }
}
