using Domain.Entities;

namespace UseCasesCommand.Gateway.Repositories.ProductRepository
{
    public interface ISalesRepository
    {
        Task<SalesEntity> RegisterSaleAsync(SalesEntity saleEntity);

    }
}
