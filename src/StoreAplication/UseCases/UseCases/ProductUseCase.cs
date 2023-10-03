using Domain.Commands.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories;
using UseCases.Gateway;
using Domain.Commands.Product;
using Domain.ObjectValues.ObjectValuesProduct;
using Newtonsoft.Json;
using Domain.ObjectValues.ObjectValuesUser;
using Domain.Response.Product;
using Domain.ProductEvent;

namespace UseCases.UseCases
{
    public class ProductUseCase : IProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IStoredEventRepository _storedEvent;

        public ProductUseCase(IProductRepository productRepository, IStoredEventRepository storedEvent)
        {
            _productRepository = productRepository;
            _storedEvent = storedEvent;
        }

        public async Task<RegisterProductCommand> RegisterProductAsync(RegisterProductCommand registerProduct)
        {
            var productName = new ProductObjectName(registerProduct.Name);
            var productDescription = new ProductObjectDescription(registerProduct.Description);
            var productPrice = new ProductObjectPrice(registerProduct.Price);            
            var productCategory = new ProductObjectCategory(registerProduct.Category);
            var productEntity = new ProductEntity(productName, productDescription, productPrice, productCategory, registerProduct.BranchId);

            var productResponse = await _productRepository.RegisterProductAsync(productEntity);
            await RegisterAndPersistEvent("ProductRegistered", productResponse.BranchId, registerProduct);

            return registerProduct;           
           
        }

        public async Task<ProductResponse> RegisterProductInventoryAsync(Guid productId, RegisterProductInventoryCommand registerProductInventoryCommand)
        {
            var quantity = new ProductObjectInventoryStock(registerProductInventoryCommand.Quantity);

            var productResponse = await _productRepository.RegisterProductInventoryAsync(quantity, productId);

            var eventStockResgitered = new RegisterEvent("ProductStockRegistered", registerProductInventoryCommand.Quantity, productResponse.InventoryStock, productId, productResponse.BranchId);

            await RegisterAndPersistEvent("ProductStockRegistered", productResponse.BranchId, eventStockResgitered);

            return productResponse;
        }

        public async Task<ProductResponse> registerFinalCustomerSaleAsync(Guid productId, RegisterProductSaleCommand registerProductSaleCommand)
        {
            var quantity = new ProductObjectInventoryStock(registerProductSaleCommand.Quantity);

            var productResponse = await _productRepository.RegisterProductFinalCustomerSaleAsync(quantity, productId);

            var eventSaleResgitered = new RegisterSaleEvent("ProductSaleRegistered", registerProductSaleCommand.Quantity, productId, productResponse.BranchId);

            var discount = productResponse.Price * 0.15;

            eventSaleResgitered.TotalPrice = (productResponse.Price - discount) * registerProductSaleCommand.Quantity;

            await RegisterAndPersistEvent("ProductSaleRegistered", productResponse.BranchId, eventSaleResgitered);

            return productResponse;
        }

        public async Task<ProductResponse> registerResellerSaleAsync(Guid productId, RegisterProductSaleCommand registerProductSaleCommand)
        {
            var quantity = new ProductObjectInventoryStock(registerProductSaleCommand.Quantity);

            var productResponse = await _productRepository.RegisterProductResellerSaleAsync(quantity, productId);

            var eventSaleResgitered = new RegisterSaleEvent("ProductSaleRegistered", registerProductSaleCommand.Quantity, productId, productResponse.BranchId);

            var discount = productResponse.Price * 0.05;

            eventSaleResgitered.TotalPrice = (productResponse.Price - discount) * registerProductSaleCommand.Quantity;

            await RegisterAndPersistEvent("ProductRessellerSaleRegistered", productResponse.BranchId, eventSaleResgitered);

            return productResponse;
        }

        public async Task RegisterAndPersistEvent(string eventName, Guid aggregateId, Object eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));

            await _storedEvent.RegisterEvent(storedEvent);
        }
      
    }
}
