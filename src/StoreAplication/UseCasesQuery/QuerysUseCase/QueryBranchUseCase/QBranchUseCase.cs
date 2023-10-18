using Domain.Entities;
using Domain.ObjectValues.ObjectValuesBranch;
using Domain.Response.Branch;
using Newtonsoft.Json;
using UseCasesCommand.Gateway.Repositories.BranchRepository;
using UseCasesQuery.RepositoriesQ.BranchRepositoryQ;

namespace UseCasesQuery.QuerysUseCase.QueryBranchUseCase
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
