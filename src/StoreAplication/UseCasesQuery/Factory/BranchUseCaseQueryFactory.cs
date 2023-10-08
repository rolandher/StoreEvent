﻿using Domain.Factory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories;

namespace UseCasesQuery.Factory
{
    public class BranchUseCaseQueryFactory : IBranchUseCaseQueryFactory
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BranchUseCaseQueryFactory(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public IBranchUseCaseQuery Create()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<IBranchUseCaseQuery>();
        }
    }
}
