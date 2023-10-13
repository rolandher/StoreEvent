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
using UseCases.Gateway.Repositories.UserRepository;
using UseCases.UseCases.UserCase;

namespace UseCasesQuery.QuerysUseCase.QueryUserUseCase
{
    public class QUserUseCase : IUserRegisterUseCase
    {

        private readonly IUserRepository _userRepository;
        
        public QUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;            
        }

        public async Task<UserResponse> RegisterUserAsync(string user)
        {
            UserEntity userToCreate = JsonConvert.DeserializeObject<UserEntity>(user);
            var userName = new UserObjectName(userToCreate.Name.FirstName, userToCreate.Name.LastName);
            var userPassword = new UserObjectPassword(userToCreate.Password.Password);
            var userEmail = new UserObjectEmail(userToCreate.Email.Email);
            var userRole = new UserObjectRole(userToCreate.Role.Role);
            var userEntity = new UserEntity(userName, userPassword, userEmail, userRole, userToCreate.BranchId);

            var responseU = await _userRepository.RegisterUserAsync(userEntity);

            var responseVm = new UserResponse();
            responseVm.Name = $"{responseU.Name.FirstName} {responseU.Name.LastName}";
            responseVm.Password = responseU.Password.Password;
            responseVm.Email = responseU.Email.Email;            
            responseVm.Role = responseU.Role.Role;
            responseVm.BranchId = responseU.BranchId;
            responseVm.UserId = responseU.UserId;

            return responseVm;
        }

    }
}
