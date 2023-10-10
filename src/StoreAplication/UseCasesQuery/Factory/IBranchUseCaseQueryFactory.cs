using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories.BranchRepository;

namespace UseCasesQuery.Factory
{
    public interface IBranchUseCaseQueryFactory
    {
        IBranchUseCaseQuery Create();
    }
}
