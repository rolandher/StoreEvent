using AutoMapper;
using Domain.Entities;
using Domain.Response.Branch;
using Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using UseCases.Gateway.Repositories.BranchRepository;

namespace Infrastructure.SQLAdapter.Repositories
{
    public class BranchRepositoryI : IBranchRepository
    {
        private readonly DbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;

        public BranchRepositoryI(DbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
        }

        public async Task<BranchEntity> RegisterBranchAsync(BranchEntity branchEntity)
        {
            using (var context = new DbConnectionBuilder())
            {
                var branchToCreate = new RegisterBranchDTO(
                    branchEntity.Name.Name,
                    branchEntity.Location.City,
                    branchEntity.Location.Country
                );                 
                    
                context.Add(branchToCreate);
                await context.SaveChangesAsync();

                branchEntity.BranchId = branchToCreate.BranchId;
                return branchEntity;
            }

        }

        public async Task<BranchQueryResponse> GetBranchByIdAsync(Guid branchId)
        {
            RegisterBranchDTO branchWithRelatedData = await _dbConnectionBuilder.Branch
                .Include(b => b.BranchProducts)
                .Include(b => b.BranchUsers)
                .Include(b => b.BranchSales)
                .FirstOrDefaultAsync(b => b.BranchId == branchId);

            var branchQueryVm = _mapper.Map<BranchQueryResponse>(branchWithRelatedData);

            return branchQueryVm;
            
        }

        public async Task<List<BranchQueryResponse>> GetAllBranchesAsync()
        {
            List<RegisterBranchDTO> branchesWithRelatedData = await _dbConnectionBuilder.Branch
                .Include(b => b.BranchProducts)
                .Include(b => b.BranchUsers)
                .Include(b => b.BranchSales)
                .ToListAsync();

            var branchQueryVms = _mapper.Map<List<BranchQueryResponse>>(branchesWithRelatedData);

            return branchQueryVms;
        }

    }
}
