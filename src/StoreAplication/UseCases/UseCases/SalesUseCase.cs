using Domain.Commands.Sales;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesSales;
using Domain.Response.Sale;
using Newtonsoft.Json;
using UseCases.Gateway;
using UseCases.Gateway.Repositories;

namespace UseCases.UseCases
{
    public class SalesUseCase
    {
        //private readonly ISalesRepository _salesRepository;
        //private readonly IStoredEventRepository _storedEvent;
        //public SalesUseCase(ISalesRepository salesRepository, IStoredEventRepository storedEvent)
        //{
        //    _salesRepository = salesRepository;
        //    _storedEvent = storedEvent;
        //}

        //public async Task<SaleResponse> RegisterSalesAsync(RegisterSalesCommand registerSale)
        //{
        //    var saleNumber = new SalesObjectNumber(registerSale.Number);
        //    var saleQuantity = new SalesObjectQuantity(registerSale.Quantity);
        //    var saleType = new SalesObjectType(registerSale.Type);
        //    var saleTotal = new SalesObjectTotal(registerSale.Total);
        //    var saleEntity = new SalesEntity(saleNumber, saleQuantity, saleType, saleTotal, registerSale.BranchId);

        //    var saleResponse = await _salesRepository.RegisterSaleAsync(saleEntity);
        //    var responseSale = new SaleResponse();


        //    responseSale.Number = registerSale.Number;
        //    responseSale.Quantity = registerSale.Quantity;
        //    responseSale.Type = registerSale.Type;
        //    responseSale.Total = registerSale.Total;
        //    responseSale.BranchId = registerSale.BranchId;
        //    responseSale.SalesId = saleResponse.SalesId;

        //    await RegisterAndPersistEvent("RegisterSale", saleResponse.SalesId, registerSale);
        //    return responseSale;

        //}

        //public async Task RegisterAndPersistEvent(string eventName, Guid aggregateId, RegisterSalesCommand eventBody)
        //{
        //    var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));

        //    await _storedEvent.RegisterEvent(storedEvent);
        //}

    }

}
