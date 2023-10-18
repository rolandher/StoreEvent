﻿using Moq;
using UseCasesCommand.Gateway.Repositories.ProductRepository;

namespace TestStore.TestProductUseCase
{
    public class TestProduct
    {
        private readonly Mock<IProductRepository> _mockUserRepository;

        public TestProduct()
        {
            _mockUserRepository = new();
        }

        [Fact]

        public async Task RegisterProductAsync()
        {
            //// Arrange
            //var productEntity = new ProductEntity("Name", "Description", "Price");

            //var productResponse = new ProductResponse();

            //productResponse.Name = "Name";
            //productResponse.Description = "Description";
            //productResponse.Price = "Price";
            //productResponse.ProductId = Guid.NewGuid();

            //_mockUserRepository.Setup(x => x.RegisterProductAsync(productEntity).ReturnsAsync(productResponse);

            // var productUseCase = new ProductUseCase(_mockUserRepository.Object);

            //// Act

            //var result = await productUseCase.RegisterProductAsync(new RegisterProductCommand("Name", "Description", "Price"));

            //// Assert

            //Assert.NotNull(result);

            //Assert.Equal(productResponse.Name, result.Name);

            //Assert.Equal(productResponse.Description, result.Description);

            //Assert.Equal(productResponse.Price, result.Price);

            //Assert.Equal(productResponse.ProductId, result.ProductId);

        }

    }
}
