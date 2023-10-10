using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories.ProductRepository;

namespace UseCasesQuery.Factory
{
    public interface IProductUseCaseQueryFactory
    {
        IProductUseCaseQuery Create();
        IProductCustomerSaleUseCaseQuery RegisterCustomerSale();
        IProductResellerSaleUseCaseQuery RegisterResellerSale();
        IProductInventoryStockUseCaseQuery RegisterProductStock();

    }
}
