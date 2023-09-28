using Domain.Commands.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway;
using UseCases.Gateway.Repositories;

namespace UseCases.UseCases
{
    public class UserUseCase : IUserUseCase
    {
        private readonly IUserRepository _userRepository;
        public UserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<RegisterUser> CreateUserAsync(Users user)
        {
            return await _userRepository.CreateUserAsync(user);
        }
    }
}
