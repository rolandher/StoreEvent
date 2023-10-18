using Domain.Commands.Product;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesProduct;
using Newtonsoft.Json;
using UseCasesCommand.Gateway.Repositories;
using UseCasesCommand.Gateway.Repositories.ProductRepository;

namespace UseCasesCommand.UseCases.ProductCase
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

            var eventResponse = await RegisterAndPersistEvent("ProductRegistered", productEntity.BranchId, productEntity);

            _publishEventRepository.PublishRegisterProduct(eventResponse);
            return registerProduct;


        }

        public async Task<StoredEventEntity> RegisterAndPersistEvent(string eventName, Guid aggregateId, object eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));
            await _storedEvent.RegisterEvent(storedEvent);
            return storedEvent;
        }

    }
}
