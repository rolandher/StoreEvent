using Domain.Response.User;
using Microsoft.AspNetCore.Mvc;

namespace StoreApiQuery.Controllers.UserQuery
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserQueryController : ControllerBase
    {
        //private readonly IUserQueryRepository _userQueryRepository;

        //public UserQueryController(IUserQueryRepository userQueryRepository)
        //{
        //    _userQueryRepository = userQueryRepository;
        //}

        //[HttpGet]
        //public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        //{
        //    var users = await _userQueryRepository.GetAllUsersAsync();
        //    return users;
        //}       

       

    }
}
