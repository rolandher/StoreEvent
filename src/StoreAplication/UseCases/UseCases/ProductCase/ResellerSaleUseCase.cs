using Domain.Commands.Product;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesSales;
using Domain.Response.Sale;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories;
using UseCases.Gateway.Repositories.ProductRepository;

namespace UseCases.UseCases.ProductCase
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



        public async Task<SaleResponse> RegisterProductResellerSaleAsync(RegisterSaleCommand registerSale)
        {
            double totalPrice = 0;
            foreach (var item in registerSale.Products)
            {
                var productResponse = await _productRepository.GetProductByIdAsync(item.ProductId);

                if (productResponse.InventoryStock < item.Quantity)
                {
                    throw new Exception($"No hay suficiente stock para el producto: {productResponse.Name}");
                }

                var discount = productResponse.Price * 0.25;
                var price = (productResponse.Price - discount) * item.Quantity;
                totalPrice += price;
            }

            var saleNumber = new SalesObjectNumber(registerSale.Number);
            var saleQuantity = new SalesObjectQuantity(registerSale.Products.Count);
            var saleType = new SalesObjectType("ResellerSale");
            var saleTotal = new SalesObjectTotal(totalPrice);

            var saleEntity = new SalesEntity(saleNumber, saleQuantity, saleType, saleTotal, registerSale.BranchId);

            var saleResponseS = new SaleResponse();
            saleResponseS.Number = saleEntity.Number.Number;
            saleResponseS.Quantity = saleEntity.Quantity.Quantity;
            saleResponseS.Type = saleEntity.Type.Type;
            saleResponseS.Total = saleEntity.Total.Total;
            saleResponseS.BranchId = saleEntity.BranchId;
            saleEntity.SalesId = saleEntity.SalesId;


            var eventResponse = await RegisterAndPersistEvent("ProductResellerSaleRegistered", registerSale.BranchId, saleEntity);

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
