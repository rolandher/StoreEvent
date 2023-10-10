using Domain.Response.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateway.Repositories.BranchRepository
{
    public interface IBranchUseCaseQuery
    {
        Task<BranchResponse> RegisterBranch(string branch);
    }
}
