using AutoMapper;
using Domain.Commands.User;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using UseCases.Gateway;

namespace StoreAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserUseCase _userUseCase;
        
        public UserController(IUserUseCase userUseCase)
        {
            _userUseCase = userUseCase;
            
        }
        
        [HttpPost]
        public async Task<int> RegisterUserAsync([FromBody] RegisterUserCommand registerUserCommand)
        {
            return await _userUseCase.RegisterUserAsync(registerUserCommand);
        }


    }
}
