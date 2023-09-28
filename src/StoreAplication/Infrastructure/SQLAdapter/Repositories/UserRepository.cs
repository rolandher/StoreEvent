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

        public async Task<RegisterUser> CreateUserAsync(Users user)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var userToCreate = new Users
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                UserPassword = user.UserPassword,
                UserRole = user.UserRole
            };

            string sqlQuery = $"INSERT INTO {_tableName} (UserId, UserName, UserPassword, UserEmail, UserRole) VALUES (@UserId, @UserName, @UserPassword, @UserEmail, @UserRole)";
            
            var result = await connection.ExecuteAsync(sqlQuery, userToCreate);
            connection.Close();
            return _mapper.Map<RegisterUser>(userToCreate);

        }

    }
}
