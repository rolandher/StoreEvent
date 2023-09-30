using AutoMapper;
using Domain.Commands.Branch;
using Domain.Commands.User;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using UseCases.Gateway;
using UseCases.UseCases;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StoreAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {

        private readonly IBranchUseCase _branchUseCase;

        public BranchController(IBranchUseCase branchUseCase)
        {
            _branchUseCase = branchUseCase;
        }

        [HttpPost]
        public async Task<int> RegisterBranchAsync([FromBody] RegisterBranchCommand registerBranchCommand)
        {
            return await _branchUseCase.RegisterBranchAsync(registerBranchCommand);
        }

    }
}
