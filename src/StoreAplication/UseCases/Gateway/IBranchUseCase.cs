using Domain.Commands.Branch;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateway
{
    public interface IBranchUseCase
    {
        Task<RegisterBranch> CreateBranchAsync(Branchs branch);
    }
}
