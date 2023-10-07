using Domain.Commands.Sales;
using Domain.Response.Sale;

namespace UseCases.Gateway
{
    public interface ISalesUseCase
    {
        Task<SaleResponse> RegisterSalesAsync(RegisterSalesCommand registerSales);
    }
}
