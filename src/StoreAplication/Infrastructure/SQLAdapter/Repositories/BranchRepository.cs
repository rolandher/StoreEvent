using AutoMapper;
using Dapper;
using Domain.Commands.Branch;
using Domain.Entities;
using Domain.ObjectValues;
using Infrastructure.DTO;
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
        private readonly DbConnectionBuilder _dbConnectionBuilder;

        public BranchRepository(DbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<int> RegisterBranchAsync(BranchEntity branchEntity)
        {
            var branchToCreate = new RegisterBranchDTO(

            branchEntity.Name.Name,
            branchEntity.Location.Country,
            branchEntity.Location.City);

            _dbConnectionBuilder.Add(branchToCreate);

            await _dbConnectionBuilder.SaveChangesAsync();

            return branchToCreate.BranchId;
        }

    }
}
