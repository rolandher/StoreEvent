using Domain.Response.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateway.Repositories.ProductRepository
{
    public interface IProductResellerSaleUseCaseQuery
    {
        Task<SaleResponse> RegisterResellerSale(string product);
    }
}
