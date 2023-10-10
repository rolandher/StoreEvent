using Domain.Response.User;
using Microsoft.AspNetCore.Mvc;
using UseCasesQuery.QuerysUseCase.QueryUserUseCase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreApiQuery.Controllers.SalesQuery
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesQueryController : ControllerBase
    {
        private readonly QUserGetIdUseCase _qUserGetIdUseCase;
        private readonly QUserGetAllUseCase _qUserGetAllUseCase;

        public SalesQueryController (QUserGetIdUseCase qUserGetIdUseCase, QUserGetAllUseCase qUserGetAllUseCase)
        {
            _qUserGetIdUseCase = qUserGetIdUseCase;
            _qUserGetAllUseCase = qUserGetAllUseCase;
        }

        [HttpGet("GetUser/{id}")]
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
