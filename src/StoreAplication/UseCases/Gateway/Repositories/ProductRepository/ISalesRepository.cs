using Domain.Entities;

namespace UseCases.Gateway.Repositories.ProductRepository
{
    public interface ISalesRepository
    {
        Task<SalesEntity> RegisterSaleAsync(SalesEntity saleEntity);

    }
}
