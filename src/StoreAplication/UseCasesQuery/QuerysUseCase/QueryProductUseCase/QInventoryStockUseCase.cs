﻿using Domain.ObjectValues.ObjectValuesProduct;
using Domain.ProductEvent;
using Domain.Response.Product;
using Newtonsoft.Json;
using UseCasesCommand.Gateway.Repositories.ProductRepository;
using UseCasesQuery.RepositoriesQ.ProductRepositoryQ;

namespace UseCasesQuery.QuerysUseCase.QueryProductUseCase
{
    public class QInventoryStockUseCase : IProductInventoryStockUseCaseQuery
    {
        private readonly IProductRepository _repository;

        public QInventoryStockUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponse> RegisterProductInventoryStock(string product)
        {
            RegisterStockEvent productStock = JsonConvert.DeserializeObject<RegisterStockEvent>(product);
            var quatity = new ProductObjectInventoryStock(productStock.Quantity);

            var productResponse = await _repository.RegisterProductInventoryAsync(quatity, productStock.ProductId);

            return productResponse;
        }


    }
}
