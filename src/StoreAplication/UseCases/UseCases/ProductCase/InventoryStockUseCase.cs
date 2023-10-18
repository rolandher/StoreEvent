using Domain.Commands.Product;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesProduct;
using Domain.ProductEvent;
using Domain.Response.Product;
using Newtonsoft.Json;
using UseCasesCommand.Gateway.Repositories;
using UseCasesCommand.Gateway.Repositories.ProductRepository;

namespace UseCasesCommand.UseCases.ProductCase
{
    public class InventoryStockUseCase
    {
        private readonly IStoredEventRepository _storedEvent;
        private readonly IPublishEventRepository _publishEventRepository;
        private readonly IProductRepository _productRepository;

        public InventoryStockUseCase(IStoredEventRepository storedEvent, IPublishEventRepository publishEventRepository, IProductRepository productRepository)
        {
            _storedEvent = storedEvent;
            _publishEventRepository = publishEventRepository;
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> RegisterProductInventoryAsync(Guid productId, RegisterProductInventoryCommand registerProductInventoryCommand)
        {
            var quantity = new ProductObjectInventoryStock(registerProductInventoryCommand.Quantity);

            var productResponse = await _productRepository.GetProductByIdAsync(productId);

            var eventStockResgitered = new RegisterStockEvent(registerProductInventoryCommand.Quantity, productId);

            var eventResponse = await RegisterAndPersistEvent("ProductStockRegistered", productResponse.BranchId, eventStockResgitered);

            _publishEventRepository.PublishRegisterProductInvetoryStock(eventResponse);
            return productResponse;
        }

        public async Task<StoredEventEntity> RegisterAndPersistEvent(string eventName, Guid aggregateId, object eventBody)
        {
            var storedEvent = new StoredEventEntity(eventName, aggregateId, JsonConvert.SerializeObject(eventBody));
            await _storedEvent.RegisterEvent(storedEvent);
            return storedEvent;
        }

    }
}
