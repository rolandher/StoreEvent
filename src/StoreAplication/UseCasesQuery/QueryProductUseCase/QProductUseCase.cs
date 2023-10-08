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

namespace UseCasesQuery.QueryProductUseCase
{
    public class QProductUseCase
    {
        private readonly IStoredEventRepository _storedEvent;
        private readonly IPublishEventRepository _publishEventRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISalesRepository _saleRepository;

        public QProductUseCase(IStoredEventRepository storedEvent, IPublishEventRepository publishEventRepository, ISalesRepository salesRepository, IProductRepository productRepository)
        {
            _storedEvent = storedEvent;
            _publishEventRepository = publishEventRepository;
            _productRepository = productRepository;
            _saleRepository = salesRepository;
        }

        public async Task<RegisterProductCommand> RegisterProductAsync(RegisterProductCommand registerProduct)
        {
            var productName = new ProductObjectName(registerProduct.Name);
            var productDescription = new ProductObjectDescription(registerProduct.Description);
            var productPrice = new ProductObjectPrice(registerProduct.Price);
            var productInventoryStock = new ProductObjectInventoryStock(registerProduct.InventoryStock);
            var productCategory = new ProductObjectCategory(registerProduct.Category);
            var productEntity = new ProductEntity(productName, productDescription, productPrice, productInventoryStock, productCategory, registerProduct.BranchId);

            var productResponse = await _productRepository.RegisterProductAsync(productEntity);
            await RegisterAndPersistEvent("ProductRegistered", productResponse.BranchId, registerProduct);

            return registerProduct;

        }

        public async Task<ProductResponse> RegisterProductInventoryAsync(Guid productId, RegisterProductInventoryCommand registerProductInventoryCommand)
        {
            var quatity = new ProductObjectInventoryStock(registerProductInventoryCommand.Quantity);

            var productResponse = await _productRepository.RegisterProductInventoryAsync(quatity, productId);

            var eventStockResgitered = new RegisterStockEvent(registerProductInventoryCommand.Quantity, productId);

            await RegisterAndPersistEvent("ProductStockRegistered", productResponse.BranchId, eventStockResgitered);
            return productResponse;
        }

        public async Task<SaleResponse> registerProductFinalCustomerSaleAsync(RegisterSaleCommand registerSaleCommand)
        {
            double totalPrice = 0;
            foreach (var item in registerSaleCommand.Products)
            {
                var productResponse = await _productRepository.registerProductFinalCustomerSaleAsync(item);

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
            var saleEntityResponse = await _saleRepository.RegisterSaleAsync(saleEntity);

            var saleResponseP = new SaleResponse();
            saleResponseP.Number = saleEntity.Number.Number;
            saleResponseP.Quantity = saleEntity.Quantity.Quantity;
            saleResponseP.Type = saleEntity.Type.Type;
            saleResponseP.Total = saleEntity.Total.Total;
            saleResponseP.BranchId = saleEntity.BranchId;
            saleEntity.SalesId = saleEntity.SalesId;           

            await RegisterAndPersistEvent("ProductFinalCustomerSaleRegistered", registerSaleCommand.BranchId, saleEntity);
            return saleResponseP;
        }

        public async Task<SaleResponse> registerProductResellerSaleAsync(RegisterSaleCommand registerSale)
        {
            double totalPrice = 0;
            foreach (var item in registerSale.Products)
            {
                var productResponse = await _productRepository.registerProductResellerSaleAsync(item);

                if (productResponse.InventoryStock < item.Quantity)
                {
                    throw new Exception($"No hay suficiente stock para el producto: {productResponse.Name}");
                }

                var discount = productResponse.Price * 0.15;
                var price = (productResponse.Price - discount) * item.Quantity;
                totalPrice += price;
            }

            var saleNumber = new SalesObjectNumber(registerSale.Number);
            var saleQuantity = new SalesObjectQuantity(registerSale.Products.Count);
            var saleType = new SalesObjectType("ResellerSale");
            var saleTotal = new SalesObjectTotal(totalPrice);

            var saleEntity = new SalesEntity(saleNumber, saleQuantity, saleType, saleTotal, registerSale.BranchId);
            var saleEntityResponse = await _saleRepository.RegisterSaleAsync(saleEntity);

            var saleResponse = new SaleResponse();
            saleResponse.Number = saleEntity.Number.Number;
            saleResponse.Quantity = saleEntity.Quantity.Quantity;
            saleResponse.Type = saleEntity.Type.Type;                
            saleResponse.Total = saleEntity.Total.Total;
            saleResponse.BranchId = saleEntity.BranchId;
            saleEntity.SalesId = saleEntity.SalesId;

            await RegisterAndPersistEvent("ProductResellerSaleRegistered", registerSale.BranchId, saleEntity);
            return saleResponse;

        }

        public async Task<StoredEventEntity> RegisterAndPersistEvent(string eventName, Guid aggregateId, Object eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));
            await _storedEvent.RegisterEvent(storedEvent);
            return storedEvent;
        }
    }
}
