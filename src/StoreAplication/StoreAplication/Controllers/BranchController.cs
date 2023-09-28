using AutoMapper;
using Domain.Commands.Branch;
using Domain.Commands.User;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using UseCases.Gateway;
using UseCases.UseCases;

namespace StoreAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {

        private readonly IBranchUseCase _branchUseCase;
        private readonly IMapper _mapper;


        public BranchController(IBranchUseCase branchUseCase, IMapper mapper)
        {
            _branchUseCase = branchUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<RegisterBranch> CreateBranchAsync([FromBody] RegisterBranch registerBranch)
        {
            return await _branchUseCase.CreateBranchAsync(_mapper.Map<Branchs>(registerBranch));
        }





    }
}
