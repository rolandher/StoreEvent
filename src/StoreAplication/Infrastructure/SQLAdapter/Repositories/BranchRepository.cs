using AutoMapper;
using Dapper;
using Domain.Commands.Branch;
using Domain.Entities;
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

        public async Task<RegisterBranch> CreateBranchAsync(Branchs branch)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var branchToCreate = new Branchs
            {
                BranchId = branch.BranchId,
                BranchName = branch.BranchName,
                BranchLocation = branch.BranchLocation                
            };

            string sqlQuery = $"INSERT INTO {_tableName} (BranchId, BranchName, BranchLocation) VALUES ( @BranchID, @BranchName, @BranchLocation)";

            var result = await connection.ExecuteAsync(sqlQuery, branchToCreate);
            connection.Close();
            return _mapper.Map<RegisterBranch>(branchToCreate);
        }
    }
}
