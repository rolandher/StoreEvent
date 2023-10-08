﻿using Domain.Commands.Product;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesProduct;
using Domain.ObjectValues.ObjectValuesSales;
using Domain.ProductEvent;
using Domain.Response.Product;
using Domain.Response.Sale;
using Newtonsoft.Json;
using UseCases.Gateway;
using UseCases.Gateway.Repositories;

namespace UseCases.UseCases
{
    public class ProductUseCase
    {
        private readonly IStoredEventRepository _storedEvent;
        private readonly IPublishEventRepository _publishEventRepository;
        private readonly IProductRepository _productRepository;

        public ProductUseCase(IStoredEventRepository storedEvent, IPublishEventRepository publishEventRepository, IProductRepository productRepository)
        {
            _storedEvent = storedEvent;
            _publishEventRepository = publishEventRepository;
            _productRepository = productRepository;
        }

        public async Task<RegisterProductCommand> RegisterProductAsync(RegisterProductCommand registerProduct)
        {
            var productName = new ProductObjectName(registerProduct.Name);
            var productDescription = new ProductObjectDescription(registerProduct.Description);
            var productPrice = new ProductObjectPrice(registerProduct.Price);
            var productInventoryStock = new ProductObjectInventoryStock(registerProduct.InventoryStock);
            var productCategory = new ProductObjectCategory(registerProduct.Category);            
            var productEntity = new ProductEntity(productName, productDescription, productPrice, productInventoryStock, productCategory, registerProduct.BranchId);

            var eventResponse = await RegisterAndPersistEvent("ProductRegistered", productEntity.BranchId, registerProduct);

            _publishEventRepository.PublishRegisterProduct(eventResponse);
            return registerProduct;

        }

        public async Task<ProductResponse> RegisterProductInventoryAsync(Guid productId, RegisterProductInventoryCommand registerProductInventoryCommand)
        {
            var quantity = new ProductObjectInventoryStock(registerProductInventoryCommand.Quantity);

            var productResponse = await _productRepository.GetProductById(productId);

            var eventStockResgitered = new RegisterStockEvent(registerProductInventoryCommand.Quantity, productId);

            var eventResponse = await RegisterAndPersistEvent("ProductStockRegistered", productResponse.BranchId, eventStockResgitered);

            _publishEventRepository.PublishRegisterProductInvetoryStock(eventResponse);
            return productResponse;
        }

        public async Task<SaleResponse> RegisterProductFinalCustomerSaleAsync(RegisterSaleCommand registerSaleCommand)
        {
            double totalPrice = 0;
            foreach (var item in registerSaleCommand.Products)
            {
                var productResponse = await _productRepository.GetProductById(item.ProductId);

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
            var saleTotal = new SalesObjectTotal (totalPrice);

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

        public async Task<SaleResponse> RegisterProductResellerSaleAsync(RegisterSaleCommand registerSale)
        {
            double totalPrice = 0;
            foreach (var item in registerSale.Products)
            {
                var productResponse = await _productRepository.GetProductById(item.ProductId);

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

        public async Task<StoredEventEntity> RegisterAndPersistEvent(string eventName, Guid aggregateId, Object eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));
            await _storedEvent.RegisterEvent(storedEvent);
            return storedEvent;
        }

    }
}
