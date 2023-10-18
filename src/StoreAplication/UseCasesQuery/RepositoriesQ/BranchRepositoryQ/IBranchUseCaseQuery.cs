using Domain.Response.Branch;

namespace UseCasesQuery.RepositoriesQ.BranchRepositoryQ
{
    public interface IBranchUseCaseQuery
    {
        Task<BranchResponse> RegisterBranch(string branch);
    }
}
