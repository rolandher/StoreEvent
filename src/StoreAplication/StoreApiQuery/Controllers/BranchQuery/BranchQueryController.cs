using Domain.Response.Branch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UseCasesQuery.QuerysUseCase.QueryBranchUseCase;

namespace StoreApiQuery.Controllers.BranchQuery
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchQueryController : ControllerBase
    {
        private readonly QBranchGetIdUseCase _getBrachByIdUseCase;
        private readonly QBranchGetAllUseCase _getAllBranchUseCase;

        public BranchQueryController(QBranchGetIdUseCase getBrachByIdUseCase, QBranchGetAllUseCase getAllBranchUseCase)
        {
            _getBrachByIdUseCase = getBrachByIdUseCase;
            _getAllBranchUseCase = getAllBranchUseCase;
        }

        [HttpGet("GetCategory/{id}")]
        public async Task<BranchQueryResponse> GetBranchById(Guid branchId)
        {
            return await _getBrachByIdUseCase.GetBranchIdAsync(branchId);
        }

        [HttpGet("GetAllBranch")]
        public async Task<List<BranchQueryResponse>> GetAllBranch()
        {
            return await _getAllBranchUseCase.GetAllBranches();
        }


    }
}
