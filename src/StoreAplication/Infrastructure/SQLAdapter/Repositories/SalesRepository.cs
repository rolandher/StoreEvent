using Domain.Entities;
using Infrastructure.DTO;
using UseCases.Gateway.Repositories;

namespace Infrastructure.SQLAdapter.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly DbConnectionBuilder _dbConnectionBuilder;

        public SalesRepository(DbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<SalesEntity> RegisterSaleAsync(SalesEntity saleEntity)
        {
            var salesToCreate = new RegisterSalesDTO(

                saleEntity.Type.Type,
                saleEntity.Number.Number,
                saleEntity.Quantity.Quantity,
                saleEntity.Total.Total,
                saleEntity.BranchId);


            _dbConnectionBuilder.Add(salesToCreate);
            await _dbConnectionBuilder.SaveChangesAsync();

            saleEntity.SalesId = salesToCreate.SalesId;

            return saleEntity;
        }

    }
}
