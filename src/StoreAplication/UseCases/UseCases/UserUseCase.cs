using Domain.Commands.User;
using Domain.Entities;
using Domain.ObjectValues;
using Domain.ObjectValues.ObjectValuesUser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway;
using UseCases.Gateway.Repositories;
using static Domain.Common.Enums;

namespace UseCases.UseCases
{
    public class UserUseCase : IUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IStoredEventRepository _storedEvent;
        public UserUseCase(IUserRepository userRepository, IStoredEventRepository storedEvent)
        {
            _userRepository = userRepository;
            _storedEvent = storedEvent;
        }
        public async Task<int> RegisterUserAsync(RegisterUserCommand registerUser)
        {
            var userName = new UserObjectName(registerUser.Name, registerUser.LastName);
            var userPassword = new UserObjectPassword(registerUser.Password);
            var userEmail = new UserObjectEmail(registerUser.Email);
            var userRole = new UserObjectRole(registerUser.Role);
            var userEntity = new UserEntity(userName, userPassword, userEmail, registerUser.Role, registerUser.BranchId);
           

            var userId = await _userRepository.RegisterUserAsync(userEntity);

            await RegisterAndPersistEvent("UserRegisteredEvent", userId, registerUser);
            return userId;
        }
            

        public async Task RegisterAndPersistEvent(string eventName, int aggregateId, RegisterUserCommand eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));

            await _storedEvent.RegisterEvent(storedEvent);
        }

    }
    
}
