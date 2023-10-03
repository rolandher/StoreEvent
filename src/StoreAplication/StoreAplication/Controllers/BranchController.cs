using AutoMapper;
using Domain.Commands.Branch;
using Domain.Commands.User;
using Domain.Entities;
using Domain.Response.Branch;
using Microsoft.AspNetCore.Mvc;
using UseCases.Gateway;
using UseCases.UseCases;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StoreAplication.Controllers
{
    [Route("api/v1/branch/register")]
    [ApiController]
    public class BranchController : ControllerBase
    {

        private readonly IBranchUseCase _branchUseCase;

        public BranchController(IBranchUseCase branchUseCase)
        {
            _branchUseCase = branchUseCase;
        }

        [HttpPost("register")]
        public async Task<BranchResponse> RegisterBranchAsync([FromBody] RegisterBranchCommand registerBranchCommand)
        {
            return await _branchUseCase.RegisterBranchAsync(registerBranchCommand);
        }

    }
}
