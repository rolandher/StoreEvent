using Domain.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateway.Repositories.ProductRepository
{
    public interface IProductUseCaseQuery
    {
        Task<ProductResponse> RegisterProduct(string product);
    }
}
