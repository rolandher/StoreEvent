using Domain.Entities;
using Domain.Response.Branch;

namespace UseCasesCommand.Gateway.Repositories.BranchRepository
{
    public interface IBranchRepository
    {
        Task<BranchEntity> RegisterBranchAsync(BranchEntity branchEntity);

        Task<BranchQueryResponse> GetBranchByIdAsync(Guid branchId);

        Task<List<BranchQueryResponse>> GetAllBranchesAsync();
    }
}
