using Domain.Commands.User;
using Domain.Response.User;

namespace UseCases.Gateway
{
    public interface IUserUseCase
    {       
        Task<UserResponse> RegisterUserAsync(RegisterUserCommand registerUser);
    }
}
