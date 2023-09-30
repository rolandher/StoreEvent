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

        public async Task<int> RegisterProductAsync(RegisterProductCommand registerProduct)
        {
            var productName = new ProductObjectName(registerProduct.Name);
            var productDescription = new ProductObjectDescription(registerProduct.Description);
            var productPrice = new ProductObjectPrice(registerProduct.Price);
            var productInventoryStock = new ProductObjectInventoryStock(registerProduct.InventoryStock);
            var productEntity = new ProductEntity(productName, productDescription, productPrice, productInventoryStock, 
                registerProduct.Category, registerProduct.BranchId);
                
            var productId = await _productRepository.RegisterProductAsync(productEntity);
            await RegisterAndPersistEvent("ProductRegistered", productId, registerProduct);

            return productId;

        }

        public async Task RegisterAndPersistEvent(string eventName, int aggregateId, RegisterProductCommand eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));

            await _storedEvent.RegisterEvent(storedEvent);
        }
    }
}
