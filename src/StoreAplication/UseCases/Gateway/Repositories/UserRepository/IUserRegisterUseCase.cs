using Domain.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateway.Repositories.UserRepository
{
    public interface IUserRegisterUseCase
    {
        Task<UserResponse> RegisterUserAsync(string user);
    }
}
