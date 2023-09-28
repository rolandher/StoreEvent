using Domain.Commands.Branch;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway;
using UseCases.Gateway.Repositories;

namespace UseCases.UseCases
{
    public class BranchUseCase : IBranchUseCase
    {
        
         private readonly IBranchRepository _branchRepository;
         public BranchUseCase(IBranchRepository branchRepository)
         { 
        _branchRepository = branchRepository;
         }
        public async Task<RegisterBranch> CreateBranchAsync(Branchs branch)
        {
        return await _branchRepository.CreateBranchAsync(branch);
        }
    }
}



