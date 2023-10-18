using Domain.Commands.Branch;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesBranch;
using Domain.Response.Branch;
using Newtonsoft.Json;
using UseCasesCommand.Gateway.Repositories;

namespace UseCasesCommand.UseCases.BranchCase
{
    public class BranchUseCase
    {

        private readonly IStoredEventRepository _storedEvent;
        private readonly IPublishEventRepository _publishEventRepository;

        public BranchUseCase(IStoredEventRepository storedEvent, IPublishEventRepository publishEventRepository)
        {
            _storedEvent = storedEvent;
            _publishEventRepository = publishEventRepository;
        }

        public async Task<BranchResponse> RegisterBranchAsync(RegisterBranchCommand registerBranch)
        {
            var branchName = new BranchObjectName(registerBranch.Name);
            var branchLocation = new BranchObjectLocation(registerBranch.Location.City, registerBranch.Location.Country);
            var branchEntity = new BranchEntity(branchName, branchLocation);

            var responseB = new BranchResponse();

            responseB.Name = registerBranch.Name;
            responseB.Location = $"{branchEntity.Location.City}, {branchEntity.Location.Country}";
            responseB.BranchId = branchEntity.BranchId;

            var eventResponse = await RegisterAndPersistEvent("BranchRegistered", branchEntity.BranchId, branchEntity);

            _publishEventRepository.PublishRegisterBranchEvent(eventResponse);

            return responseB;
        }

        public async Task<StoredEventEntity> RegisterAndPersistEvent(string eventName, Guid aggregateId, object eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));
            await _storedEvent.RegisterEvent(storedEvent);
            return storedEvent;
        }

    }
}



