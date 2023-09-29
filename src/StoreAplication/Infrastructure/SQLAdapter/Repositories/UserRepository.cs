using AutoMapper;
using Dapper;
using Domain.Commands.User;
using Domain.Entities;
using Domain.ObjectValues;
using Infrastructure.SQLAdapter.Gateway;
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
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;
        private readonly string _tableName = "Users";

        public UserRepository(IDbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
        }

        public async Task<RegisterUserCommand> RegisterUserAsync(Users user)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var userToCreate = new Users
            {
                UserName = user.UserName,
                IdBranch = user.IdBranch,
                UserEmail = user.UserEmail,
                UserPassword = user.UserPassword,
                UserRole = user.UserRole
            };

            string sqlQuery = $"INSERT INTO {_tableName} (UserName, IdBranch, UserPassword, UserEmail, UserRole) VALUES (@UserName, @IdBranch, @UserPassword, @UserEmail, @UserRole)";
            
            var result = await connection.ExecuteAsync(sqlQuery, userToCreate);
            connection.Close();
            return _mapper.Map<RegisterUserCommand>(userToCreate);

        }

    }
}
