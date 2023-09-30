using Domain.Commands.Branch;
using Domain.Entities;
using Domain.ObjectValues;
using Domain.ObjectValues.ObjectValuesBranch;
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

        public async Task<int> RegisterBranchAsync(RegisterBranchCommand registerBranch)
        {
            var branchName = new BranchObjectName(registerBranch.Name);
            var branchLocation = new BranchObjectLocation(registerBranch.Country, registerBranch.City);
            var branchEntity = new BranchEntity(branchName, branchLocation);
            var branchId = await _branchRepository.RegisterBranchAsync(branchEntity);

            
            await RegisterAndPersistEvent("BranchRegisteredEvent", branchId, registerBranch);

            return branchId;
                        
        }

        public async Task RegisterAndPersistEvent(string eventName, int aggregateId, RegisterBranchCommand eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));

            await _storedEvent.RegisterEvent(storedEvent);
        }
    }
}



