using Domain.Response.Branch;
using UseCasesCommand.Gateway.Repositories.BranchRepository;

namespace UseCasesQuery.QuerysUseCase.QueryBranchUseCase
{
    public class QBranchGetAllUseCase
    {
        private readonly IBranchRepository _repository;

        public QBranchGetAllUseCase(IBranchRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BranchQueryResponse>> GetAllBranches()
        {
            return await _repository.GetAllBranchesAsync();
        }

    }
}
