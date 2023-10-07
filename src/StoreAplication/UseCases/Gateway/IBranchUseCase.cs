using Domain.Commands.Branch;
using Domain.Response.Branch;

namespace UseCases.Gateway
{
    public interface IBranchUseCase
    {
        Task<BranchResponse> RegisterBranchAsync(RegisterBranchCommand registerBranch);
    }
}
