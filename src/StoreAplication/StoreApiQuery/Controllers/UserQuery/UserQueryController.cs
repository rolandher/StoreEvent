using Domain.Response.User;
using Microsoft.AspNetCore.Mvc;
using UseCasesQuery.QuerysUseCase.QueryUserUseCase;

namespace ApiQuery.Controllers.UserQuery
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserQueryController : ControllerBase
    {
        private readonly QUserGetIdUseCase _qUserGetIdUseCase;
        private readonly QUserGetAllUseCase _qUserGetAllUseCase;

        public UserQueryController(QUserGetIdUseCase qUserGetIdUseCase, QUserGetAllUseCase qUserGetAllUseCase)
        {
            _qUserGetIdUseCase = qUserGetIdUseCase;
            _qUserGetAllUseCase = qUserGetAllUseCase;
        }

        [HttpGet("GetUserById")]
        public async Task<UserQueryResponse> GetUserById(Guid UserId)
        {
            return await _qUserGetIdUseCase.GetUserById(UserId);
        }

        [HttpGet("GetAllUsers")]
        public async Task<List<UserQueryResponse>> GetAllUsers()
        {
            return await _qUserGetAllUseCase.GetAllUsers();
        }

    }
}
