﻿using Domain.Entities;
using Infrastructure.DTO;
using UseCases.Gateway.Repositories.ProductRepository;

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
            using (var context = new DbConnectionBuilder())
            {
                var saleToCreate = new RegisterSalesDTO(
                saleEntity.Number.Number,
                saleEntity.Quantity.Quantity,
                saleEntity.Total.Total,
                saleEntity.Type.Type,
                saleEntity.BranchId
                );

                context.Add(saleToCreate);
                await context.SaveChangesAsync();


                return saleEntity;

            }

        }
    }
}
