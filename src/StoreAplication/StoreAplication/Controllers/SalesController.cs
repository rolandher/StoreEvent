using Domain.Commands.Sales;
using Domain.Response.Sale;
using Microsoft.AspNetCore.Mvc;
using UseCases.Gateway;

namespace StoreAplication.Controllers
{
    [Route("api/v1/sales/register")]
    [ApiController]
    public class SalesController : ControllerBase
    {

        private readonly ISalesUseCase _salesUseCase;

        public SalesController(ISalesUseCase salesUseCase)
        {
            _salesUseCase = salesUseCase;
        }

        [HttpPost("register")]
        public async Task<SaleResponse> RegisterSalesAsync([FromBody] RegisterSalesCommand registerSalesCommand)
        {
            return await _salesUseCase.RegisterSalesAsync(registerSalesCommand);
        }

    }

}
