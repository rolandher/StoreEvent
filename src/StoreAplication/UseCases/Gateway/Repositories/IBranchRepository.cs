using Domain.Commands.Branch;
using Domain.Commands.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateway.Repositories
{
    public interface IBranchRepository
    {
        Task<int> RegisterBranchAsync(BranchEntity branchEntity);
    }
}
