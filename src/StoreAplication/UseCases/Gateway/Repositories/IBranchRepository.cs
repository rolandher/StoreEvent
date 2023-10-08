using Domain.Entities;
using Domain.Response.Branch;

namespace UseCases.Gateway.Repositories
{
    public interface IBranchRepository
    {
        Task<BranchEntity> RegisterBranchAsync(BranchEntity branchEntity);

        Task<BranchQueryResponse> GetBranchByIdAsync(Guid branchId);
    }
}
