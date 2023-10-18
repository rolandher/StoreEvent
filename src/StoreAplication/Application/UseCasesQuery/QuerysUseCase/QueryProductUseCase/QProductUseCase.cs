using Domain.Entities;
using Domain.ObjectValues.ObjectValuesProduct;
using Domain.Response.Product;
using Newtonsoft.Json;
using UseCasesCommand.Gateway.Repositories.ProductRepository;
using UseCasesQuery.RepositoriesQ.ProductRepositoryQ;

namespace UseCasesQuery.QuerysUseCase.QueryProductUseCase
{
    public class QProductUseCase : IProductUseCaseQuery
    {
        private readonly IProductRepository _repository;

        public QProductUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponse> RegisterProduct(string product)
        {
            ProductEntity productToCreate = JsonConvert.DeserializeObject<ProductEntity>(product);
            var productName = new ProductObjectName(productToCreate.Name.Name);
            var productDescription = new ProductObjectDescription(productToCreate.Description.Description);
            var productPrice = new ProductObjectPrice(productToCreate.Price.Price);
            var productInventoryStock = new ProductObjectInventoryStock(productToCreate.InventoryStock.InventoryStock);
            var productCategory = new ProductObjectCategory(productToCreate.Category.Category);
            var productEntity = new ProductEntity(productName, productDescription, productPrice, productInventoryStock, productCategory, productToCreate.BranchId);

            await _repository.RegisterProductAsync(productEntity);

            var responseVm = new ProductResponse();
            responseVm.ProductId = productEntity.ProductId;
            responseVm.Name = productEntity.Name.Name;
            responseVm.Description = productEntity.Description.Description;
            responseVm.Price = productEntity.Price.Price;
            responseVm.InventoryStock = productEntity.InventoryStock.InventoryStock;
            responseVm.Category = productEntity.Category.Category;
            responseVm.BranchId = productEntity.BranchId;

            return responseVm;


        }

    }
}
