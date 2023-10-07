using Domain.Commands.Branch;
using Domain.Response.Branch;
using Microsoft.AspNetCore.Mvc;
using UseCases.Gateway;

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
