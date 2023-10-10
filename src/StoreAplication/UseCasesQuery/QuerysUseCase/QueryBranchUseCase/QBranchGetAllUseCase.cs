using Domain.Response.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories.BranchRepository;

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
