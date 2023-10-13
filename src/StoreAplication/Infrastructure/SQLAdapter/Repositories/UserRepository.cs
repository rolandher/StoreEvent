using AutoMapper;
using Domain.Entities;
using Domain.ObjectValues;
using Domain.ObjectValues.ObjectValuesUser;
using Domain.Response.User;
using Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using UseCases.Gateway.Repositories.UserRepository;

namespace Infrastructure.SQLAdapter.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;

        public UserRepository(DbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;   
        }

        public async Task<UserEntity> RegisterUserAsync(UserEntity user)
        {
            using (var context = new DbConnectionBuilder())
            {
                var userToRegistered = new RegisterUserDTO(
                $"{user.Name.FirstName} {user.Name.LastName}",
                user.Password.Password,
                user.Email.Email,
                user.Role.Role,
                user.BranchId);

                context.Add(userToRegistered);
                await context.SaveChangesAsync();

                user.UserId = userToRegistered.UserId;
                return user;
            }
        }

        public async Task<List<UserQueryResponse>> GetAllUsersAsync()
        {
            var users = await _dbConnectionBuilder.User.ToListAsync();

            var userResponseList = users.Select(user => _mapper.Map<UserQueryResponse>(user)).ToList();

            return userResponseList;
        }

        public async Task<UserQueryResponse> GetUserByIdAsync(Guid UserId)
        {
            var existingUser = await _dbConnectionBuilder.User.FindAsync(UserId);

            if (existingUser == null)
            {
                throw new ArgumentNullException("El usuario no se encontro.");
            }

            return _mapper.Map<UserQueryResponse>(existingUser);
        }

    }
}


