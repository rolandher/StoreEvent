using Domain.Response.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories.BranchRepository;

namespace UseCasesQuery.QuerysUseCase.QueryBranchUseCase
{
    public class QBranchGetIdUseCase
    {
        private readonly IBranchRepository _repository;

        public QBranchGetIdUseCase(IBranchRepository repository)
        {
            _repository = repository;
        }

        public async Task<BranchQueryResponse> GetBranchIdAsync(Guid branchId)
        {
            return await _repository.GetBranchByIdAsync(branchId);
        }
    }
}
