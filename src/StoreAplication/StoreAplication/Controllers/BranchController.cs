﻿using Domain.Commands.Branch;
using Domain.Response.Branch;
using Microsoft.AspNetCore.Mvc;
using UseCases.Gateway;
using UseCases.UseCases;

namespace StoreAplication.Controllers
{
    [Route("api/v1/branch/register")]
    [ApiController]
    public class BranchController : ControllerBase
    {

        private readonly BranchUseCase _branchUseCase;


        public BranchController(BranchUseCase branchUseCase)
        {
            _branchUseCase = branchUseCase;
        }

        [HttpPost("register")]

        public async Task<BranchResponse> RegisterBranchAsync([FromBody] RegisterBranchCommand registerBranch)
        {
            return await _branchUseCase.RegisterBranchAsync(registerBranch);
        }

    }
}
