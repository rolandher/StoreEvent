using Domain.Commands.Branch;
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
using UseCases.Gateway;
using UseCases.Gateway.Repositories;

namespace UseCases.UseCases
{
    public class BranchUseCase : IBranchUseCase
    {

        private readonly IBranchRepository _branchRepository;
        private readonly IStoredEventRepository _storedEvent;
        public BranchUseCase(IBranchRepository branchRepository, IStoredEventRepository storedEvent)
        {
            _branchRepository = branchRepository;
            _storedEvent = storedEvent;
        }

        public async Task<BranchResponse> RegisterBranchAsync(RegisterBranchCommand registerBranch)
        {
            var branchName = new BranchObjectName(registerBranch.Name);
            var branchLocation = new BranchObjectLocation(registerBranch.Location.City, registerBranch.Location.Country);
            var branchEntity = new BranchEntity(branchName, branchLocation);

            var branchResponse = await _branchRepository.RegisterBranchAsync(branchEntity);

            var responseB = new BranchResponse();

            responseB.Name = registerBranch.Name;
            responseB.Location = $"{branchResponse.Location.City}, {branchResponse.Location.Country}";
            responseB.BranchId = branchResponse.BranchId;

            await RegisterAndPersistEvent("BranchRegisteredEvent", branchResponse.BranchId, registerBranch);

            return responseB;                  

        }

        public async Task RegisterAndPersistEvent(string eventName, Guid aggregateId, RegisterBranchCommand eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));

            await _storedEvent.RegisterEvent(storedEvent);
        }
       
    }
}



