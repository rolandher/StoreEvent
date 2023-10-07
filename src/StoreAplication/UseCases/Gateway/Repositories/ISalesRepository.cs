using Domain.Entities;

namespace UseCases.Gateway.Repositories
{
    public interface ISalesRepository
    {
        Task<SalesEntity> RegisterSaleAsync(SalesEntity saleEntity);

    }
}
