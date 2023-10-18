using Domain.Entities;
using Domain.ObjectValues.ObjectValuesUser;
using Domain.Response.User;
using Newtonsoft.Json;
using UseCasesCommand.Gateway.Repositories.UserRepository;
using UseCasesQuery.RepositoriesQ.UserRepositoryQ;

namespace UseCasesQuery.QuerysUseCase.QueryUserUseCase
{
    public class QUserUseCase : IUserRegisterUseCaseQuery
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
