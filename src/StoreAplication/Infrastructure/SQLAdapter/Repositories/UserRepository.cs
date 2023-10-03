using AutoMapper;
using Dapper;
using Domain.Commands.User;
using Domain.Entities;
using Domain.ObjectValues;
using Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories;

namespace Infrastructure.SQLAdapter.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnectionBuilder _dbConnectionBuilder;
        
        public UserRepository(DbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            
        }

        public async Task<UserEntity> RegisterUserAsync(UserEntity userEntity)
        {

            var userToCreate = new RegisterUserDTO(

                $"{userEntity.Name.Name} {userEntity.Name.LastName}",
                userEntity.Password.Password,
                userEntity.Email.Email,
                userEntity.Role.Role,
                userEntity.BranchId);

            _dbConnectionBuilder.Add(userToCreate);
            await _dbConnectionBuilder.SaveChangesAsync();

            userEntity.UserId = userToCreate.UserId;

            return userEntity;
           

        }
    }
}


