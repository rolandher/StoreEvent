using Domain.Commands.User;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesUser;
using Domain.ObjectValues;
using Domain.Response.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories;

namespace UseCasesQuery.QueryUseCase
{
    public class QUserUseCase 
    {

        private readonly IUserRepository _userRepository;
        private readonly IStoredEventRepository _storedEvent;
        public QUserUseCase(IUserRepository userRepository, IStoredEventRepository storedEvent)
        {
            _userRepository = userRepository;
            _storedEvent = storedEvent;
        }

        public async Task<UserResponse> RegisterUserAsync(RegisterUserCommand registerUser)
        {
            var userName = new UserObjectName(registerUser.Name.Name, registerUser.Name.LastName);
            var userPassword = new UserObjectPassword(registerUser.Password);
            var userEmail = new UserObjectEmail(registerUser.Email);
            var userRole = new UserObjectRole(registerUser.Role);
            var userEntity = new UserEntity(userName, userPassword, userEmail, userRole, registerUser.BranchId);

            var userResponse = await _userRepository.RegisterUserAsync(userEntity);
            var responseU = new UserResponse();

            responseU.Name = $"{registerUser.Name.Name} {registerUser.Name.LastName}";
            responseU.Email = registerUser.Email;
            responseU.Password = registerUser.Password;
            responseU.Role = registerUser.Role;
            responseU.BranchId = registerUser.BranchId;
            responseU.UserId = userEntity.UserId;

            var eventResponse = await RegisterAndPersistEvent("UserRegistered", userEntity.BranchId, registerUser);                       

            return responseU;

        }

        public async Task<StoredEventEntity> RegisterAndPersistEvent(string eventName, Guid aggregateId, Object eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));
            await _storedEvent.RegisterEvent(storedEvent);
            return storedEvent;
        }




    }
}
