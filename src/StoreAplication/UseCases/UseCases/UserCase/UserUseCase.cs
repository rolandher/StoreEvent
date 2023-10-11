using Domain.Commands.User;
using Domain.Entities;
using Domain.ObjectValues;
using Domain.ObjectValues.ObjectValuesUser;
using Domain.Response.User;
using Newtonsoft.Json;
using UseCases.Gateway;
using UseCases.Gateway.Repositories;

namespace UseCases.UseCases.UserCase
{
    public class UserUseCase
    {

        private readonly IStoredEventRepository _storedEvent;
        private readonly IPublishEventRepository _publishEventRepository;

        public UserUseCase(IStoredEventRepository storedEvent, IPublishEventRepository publishEventRepository)
        {
            _storedEvent = storedEvent;
            _publishEventRepository = publishEventRepository;
        }
        public async Task<UserResponse> RegisterUserAsync(RegisterUserCommand registerUser)
        {
            var userName = new UserObjectName(registerUser.Name.Name, registerUser.Name.LastName);
            var userPassword = new UserObjectPassword(registerUser.Password);
            var userEmail = new UserObjectEmail(registerUser.Email);
            var userRole = new UserObjectRole(registerUser.Role);
            var userEntity = new UserEntity(userName, userPassword, userEmail, userRole, registerUser.BranchId);

            var responseU = new UserResponse();

            responseU.Name = $"{registerUser.Name.Name} {registerUser.Name.LastName}";
            responseU.Email = registerUser.Email;
            responseU.Password = registerUser.Password;
            responseU.Role = registerUser.Role;
            responseU.BranchId = registerUser.BranchId;
            responseU.UserId = userEntity.UserId;

            var eventResponse = await RegisterAndPersistEvent("UserRegistered", userEntity.BranchId, userEntity);

            _publishEventRepository.PublishRegisterUser(eventResponse);

            return responseU;

        }

        public async Task<StoredEventEntity> RegisterAndPersistEvent(string eventName, Guid aggregateId, object eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));
            await _storedEvent.RegisterEvent(storedEvent);
            return storedEvent;
        }

    }

}
