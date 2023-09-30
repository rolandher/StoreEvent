﻿using Domain.Commands.User;
using Domain.Entities;
using Domain.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateway
{
    public interface IUserUseCase
    {
        Task<int> RegisterUserAsync(RegisterUserCommand registerUser);
    }
}
