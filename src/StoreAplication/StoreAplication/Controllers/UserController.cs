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
        private readonly IMapper _mapper;


        public UserController(IUserUseCase userUseCase, IMapper mapper)
        {
            _userUseCase = userUseCase;
            _mapper = mapper;
        }

        
        [HttpPost]
        public async Task<RegisterUser> CreateUserAsync([FromBody] RegisterUser registerUser)
        {
            return await _userUseCase.CreateUserAsync(_mapper.Map<Users>(registerUser));
        }


    }
}
