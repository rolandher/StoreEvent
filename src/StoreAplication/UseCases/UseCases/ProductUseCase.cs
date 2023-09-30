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
            var productEntity = new ProductEntity(productName, productDescription, productPrice,
                (ProductObjectCategory)Enum.Parse(typeof(ProductObjectCategory), registerProduct.Category), registerProduct.BranchId);
                
            var productId = await _productRepository.RegisterProductAsync(productEntity);
            await RegisterAndPersistEvent("ProductRegistered", productId, registerProduct);

            return productId;

        }

        public async Task<string> RegisterProductInventoryAsync(RegisterProductInventoryCommand registerProductInventoryCommand)
        {

            var productInventoryEntity = new RegisterProductInventoryCommand(registerProductInventoryCommand.Id, registerProductInventoryCommand.Quantity);
                    
            var productInventoryId = await _productRepository.RegisterProductInventoryAsync(productInventoryEntity);

            await RegisterAndPersistEvent("ProductInventoryRegistered", productInventoryId, null);

            return productInventoryId;                       
            
        }

        public async Task<string> RegisterProductSaleAsync(RegisterProductSaleCommand productSaleCommand)
        {
            var productSaleEntity = new RegisterProductSaleCommand(productSaleCommand.Id, productSaleCommand.Quantity);

            var productSaleId = await _productRepository.RegisterProductSaleAsync(productSaleEntity);

            await RegisterAndPersistEvent("ProductSaleRegistered", productSaleId, null);

            return productSaleId;
        }

        public async Task<string> RegisterSaleAsync(RegisterSaleCommand registerSaleCommand)
        {
            var saleEntity = new RegisterSaleCommand (registerSaleCommand.Products);

            var saleId = await _productRepository.RegisterSaleAsync(saleEntity);

            await RegisterAndPersistEvent("SaleRegistered", saleId, null);

            return saleId;
        }

        public async Task RegisterAndPersistEvent(string eventName, int aggregateId, RegisterProductCommand eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));

            await _storedEvent.RegisterEvent(storedEvent);
        }     



    }
}
