using Domain.Response.Branch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UseCasesQuery.QueryBranchUseCase;

namespace StoreApiQuery.Controllers.BranchQuery
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchQueryController : ControllerBase
    {
        private readonly QBranchGetIdUseCase _getBrachByIdUseCase;

        public BranchQueryController(QBranchGetIdUseCase getBrachByIdUseCase)
        {
            _getBrachByIdUseCase = getBrachByIdUseCase;
        }

        [HttpGet("GetCategory/{id}")]
        public async Task<BranchQueryResponse> GetBranchById(Guid id)
        {
            return await _getBrachByIdUseCase.GetBranchIdAsync(id);
        }
    }
}
