using Domain.Commands.Branch;
using Domain.Entities;
using Domain.ObjectValues;
using Domain.ObjectValues.ObjectValuesBranch;
using Domain.Response.Branch;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories;
using UseCases.UseCases;

namespace TestStore.TestBranchUseCase
{
    
      public class TestBranch
      {
        private readonly Mock<IBranchRepository> _mockUserRepository;

               
        public TestBranch()
        {
            _mockUserRepository = new();
        }

        [Fact]
        public async Task RegisterBranchAsync()
        {

            // Arrange
            var branchName = new BranchObjectName("BranchName");
            var branchLocation = new BranchObjectLocation("City", "Country");
            var branchEntity = new BranchEntity(branchName, branchLocation);

            var branchResponse = new BranchResponse();

            branchResponse.Name = "BranchName";
            branchResponse.Location = "City, Country";
            branchResponse.BranchId = Guid.NewGuid();

            _mockUserRepository.Setup(x => x.RegisterBranchAsync(branchEntity).ReturnsAsync(branchResponse);

            var branchUseCase = new BranchUseCase(_mockUserRepository.Object);

            // Act

            var result = await branchUseCase.RegisterBranchAsync(new RegisterBranchCommand("BranchName", new RegisterBranchCommand.LocationCommand("City", "Country")));

            // Assert

            Assert.NotNull(result);

            Assert.Equal(branchResponse.Name, result.Name);

            Assert.Equal(branchResponse.Location, result.Location);

            Assert.Equal(branchResponse.BranchId, result.BranchId);
          
        }

      }
    
}
