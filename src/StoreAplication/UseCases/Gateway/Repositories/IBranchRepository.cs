using Domain.Entities;

namespace UseCases.Gateway.Repositories
{
    public interface IBranchRepository
    {
        Task<BranchEntity> RegisterBranchAsync(BranchEntity branchEntity);
    }
}
