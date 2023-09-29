using AutoMapper;
using Dapper;
using Domain.Commands.Branch;
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
    public class BranchRepository : IBranchRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly IMapper _mapper;
        private readonly string _tableName = "Branchs";

        public BranchRepository(IDbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
        }

        public async Task<RegisterBranchCommand> RegisterBranchAsync(Branchs branchs)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var branchToCreate = new Branchs
            {
                BranchName = branchs.BranchName,
                BranchLocation = new Location
                {
                    City = branchs.BranchLocation.City,
                    Country = branchs.BranchLocation.Country
                }
            };

            string sqlQuery = $"INSERT INTO {_tableName} (BranchName, BranchLocation) VALUES (@BranchName, @BranchLocation)";

            var result = await connection.ExecuteAsync(sqlQuery, branchToCreate);

            connection.Close();

            return _mapper.Map<RegisterBranchCommand>(branchToCreate);

            

        }
        
    }
}
