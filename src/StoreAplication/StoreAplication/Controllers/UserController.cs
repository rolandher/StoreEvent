using Domain.Commands.User;
using Domain.Response.User;
using Microsoft.AspNetCore.Mvc;
using UseCases.Gateway;

namespace StoreAplication.Controllers
{
    [Route("api/v1/user/register")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserUseCase _userUseCase;

        public UserController(IUserUseCase userUseCase)
        {
            _userUseCase = userUseCase;

        }

        [HttpPost]
        public async Task<UserResponse> RegisterUserAsync([FromBody] RegisterUserCommand registerUserCommand)
        {
            return await _userUseCase.RegisterUserAsync(registerUserCommand);
        }

    }
}
