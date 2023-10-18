using Domain.Commands.Product;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesSales;
using Domain.Response.Sale;
using Newtonsoft.Json;
using UseCasesCommand.Gateway.Repositories;
using UseCasesCommand.Gateway.Repositories.ProductRepository;

namespace UseCasesCommand.UseCases.ProductCase
{
    public class ResellerSaleUseCase
    {

        private readonly IStoredEventRepository _storedEvent;
        private readonly IPublishEventRepository _publishEventRepository;
        private readonly IProductRepository _productRepository;

        public ResellerSaleUseCase(IStoredEventRepository storedEvent, IPublishEventRepository publishEventRepository, IProductRepository productRepository)
        {
            _storedEvent = storedEvent;
            _publishEventRepository = publishEventRepository;
            _productRepository = productRepository;
        }



        public async Task<SaleResponse> RegisterProductResellerSaleAsync(RegisterSaleCommand registersalecommand)
        {
            double totalPrice = 0;
            foreach (var item in registersalecommand.Products)
            {
                var productResponse = await _productRepository.GetProductByIdAsync(item.ProductId);

                var discount = productResponse.Price * 0.25;
                var price = (productResponse.Price - discount) * item.Quantity;
                totalPrice += price;
            }

            var saleNumber = new SalesObjectNumber(registersalecommand.Number);
            var saleQuantity = new SalesObjectQuantity(registersalecommand.Products.Count);
            var saleTotal = new SalesObjectTotal(totalPrice);
            var saleType = new SalesObjectType("ResellerSale");

            var saleEntity = new SalesEntity(saleNumber, saleQuantity, saleTotal, saleType, registersalecommand.BranchId);

            var saleResponseS = new SaleResponse();
            saleResponseS.Number = saleEntity.Number.Number;
            saleResponseS.Quantity = saleEntity.Quantity.Quantity;
            saleResponseS.Total = saleEntity.Total.Total;
            saleResponseS.Type = saleEntity.Type.Type;
            saleResponseS.BranchId = saleEntity.BranchId;
            saleEntity.SalesId = saleEntity.SalesId;


            var eventResponse = await RegisterAndPersistEvent("ProductResellerSaleRegistered", registersalecommand.BranchId, registersalecommand);

            _publishEventRepository.PublishRegisterProductSaleReseller(eventResponse);
            return saleResponseS;

        }
        public async Task<StoredEventEntity> RegisterAndPersistEvent(string eventName, Guid aggregateId, object eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));
            await _storedEvent.RegisterEvent(storedEvent);
            return storedEvent;
        }
    }
}
