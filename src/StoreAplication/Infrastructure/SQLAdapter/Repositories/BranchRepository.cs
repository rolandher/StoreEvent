using Domain.Entities;
using Infrastructure.DTO;
using UseCases.Gateway.Repositories;

namespace Infrastructure.SQLAdapter.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DbConnectionBuilder _dbConnectionBuilder;

        public BranchRepository(DbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<BranchEntity> RegisterBranchAsync(BranchEntity branchEntity)
        {
            var branchToCreate = new RegisterBranchDTO(

            branchEntity.Name.Name,
            branchEntity.Location.Country,
            branchEntity.Location.City);

            _dbConnectionBuilder.Add(branchToCreate);

            await _dbConnectionBuilder.SaveChangesAsync();

            branchEntity.BranchId = branchToCreate.BranchId;

            return branchEntity;

        }

    }
}
