using AutoMapper;
using Domain.Entities;
using Domain.Response.Branch;
using Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using UseCases.Gateway.Repositories;

namespace Infrastructure.SQLAdapter.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;

        public BranchRepository(DbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
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

        public async Task<BranchQueryResponse> GetBranchByIdAsync(Guid branchId)
        {
            RegisterBranchDTO branchWithRelatedData = await _dbConnectionBuilder.Branch
                .Include(b => b.BranchProducts)
                .Include(b => b.BranchUsers)
                .Include(b => b.BranchSales)
                .FirstOrDefaultAsync(b => b.BranchId == branchId);

            var branchResponse = _mapper.Map<BranchQueryResponse>(branchWithRelatedData);

            return branchResponse;
        }

    }
}
