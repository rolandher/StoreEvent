using Domain.Commands.User;
using Domain.Entities;
using Domain.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateway.Repositories
{
    public interface IUserRepository
    {
        Task <int> RegisterUserAsync(UserEntity userEntity);
    }
}
