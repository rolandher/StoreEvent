using Domain.Commands.User;
using Domain.Response.User;
using Microsoft.AspNetCore.Mvc;
using UseCasesCommand.UseCases.UserCase;

namespace StoreAplication.Controllers
{
    [Route("api/v1/user/register")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserUseCase _userUseCase;

        public UserController(UserUseCase userUseCase)
        {
            _userUseCase = userUseCase;
        }

        [HttpPost("register")]
        public async Task<UserResponse> RegisterUserAsync([FromBody] RegisterUserCommand registerUser)
        {
            return await _userUseCase.RegisterUserAsync(registerUser);

        }

    }
}
