using Domain.Commands.Product;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesProduct;
using Domain.ObjectValues.ObjectValuesSales;
using Domain.ProductEvent;
using Domain.Response.Product;
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
    public class FinalCustomerSaleUseCase
    {
        private readonly IStoredEventRepository _storedEvent;
        private readonly IPublishEventRepository _publishEventRepository;
        private readonly IProductRepository _productRepository;

        public FinalCustomerSaleUseCase(IStoredEventRepository storedEvent, IPublishEventRepository publishEventRepository, IProductRepository productRepository)
        {
            _storedEvent = storedEvent;
            _publishEventRepository = publishEventRepository;
            _productRepository = productRepository;
        }


        public async Task<SaleResponse> RegisterProductFinalCustomerSaleAsync(RegisterSaleCommand registerSaleCommand)
        {
            double totalPrice = 0;
            foreach (var item in registerSaleCommand.Products)
            {
                var productResponse = await _productRepository.GetProductByIdAsync(item.ProductId);

                if (productResponse.InventoryStock < item.Quantity)
                {
                    throw new Exception($"No hay suficiente stock para el producto: {productResponse.Name}");
                }

                var discount = productResponse.Price * 0.15;
                var price = (productResponse.Price - discount) * item.Quantity;
                totalPrice += price;
            }

            var saleNumber = new SalesObjectNumber(registerSaleCommand.Number);
            var saleQuantity = new SalesObjectQuantity(registerSaleCommand.Products.Count);
            var saleType = new SalesObjectType("FinalCustomerSale");
            var saleTotal = new SalesObjectTotal(totalPrice);

            var saleEntity = new SalesEntity(saleNumber, saleQuantity, saleType, saleTotal, registerSaleCommand.BranchId);

            var saleResponse = new SaleResponse();
            saleResponse.Number = saleEntity.Number.Number;
            saleResponse.Quantity = saleEntity.Quantity.Quantity;
            saleResponse.Type = saleEntity.Type.Type;
            saleResponse.Total = saleEntity.Total.Total;
            saleResponse.BranchId = saleEntity.BranchId;
            saleEntity.SalesId = saleEntity.SalesId;


            var eventResponse = await RegisterAndPersistEvent("ProductFinalCustomerSaleRegistered", registerSaleCommand.BranchId, saleEntity);

            _publishEventRepository.PublishRegisterProductSaleCustomer(eventResponse);
            return saleResponse;
        }

        public async Task<StoredEventEntity> RegisterAndPersistEvent(string eventName, Guid aggregateId, object eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));
            await _storedEvent.RegisterEvent(storedEvent);
            return storedEvent;
        }
    }
}
