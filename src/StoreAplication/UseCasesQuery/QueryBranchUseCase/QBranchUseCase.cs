using Domain.Entities;
using Domain.ObjectValues;
using Domain.ObjectValues.ObjectValuesBranch;
using Domain.Response.Branch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories;

namespace UseCasesQuery.QueryBranchUseCase
{
    public class QBranchUseCase : IBranchUseCaseQuery
    {
        private readonly IBranchRepository _repository;

        public QBranchUseCase(IBranchRepository repository)
        {
            _repository = repository;
        }

        public async Task<BranchResponse> RegisterBranch(string branch)
        {
            BranchEntity branchToCreate = JsonConvert.DeserializeObject<BranchEntity>(branch);
            var branchName = new BranchObjectName(branchToCreate.Name.Name);
            var branchLocation = new BranchObjectLocation(branchToCreate.Location.Country, branchToCreate.Location.City);
            var branchEntity = new BranchEntity(branchName, branchLocation);
            await _repository.RegisterBranchAsync(branchEntity);

            var responseB = new BranchResponse();
            responseB.BranchId = branchEntity.BranchId;
            responseB.Location = $"{branchEntity.Location.City}, {branchEntity.Location.Country}";
            responseB.Name = branchEntity.Name.Name;

            return responseB;
        }

    }
}
