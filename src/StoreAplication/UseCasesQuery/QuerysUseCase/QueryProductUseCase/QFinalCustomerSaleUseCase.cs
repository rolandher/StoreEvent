using Domain.Commands.Product;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesSales;
using Domain.Response.Product;
using Domain.Response.Sale;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories;
using UseCases.Gateway.Repositories.ProductRepository;

namespace UseCasesQuery.QuerysUseCase.QueryProductUseCase
{
    public class QFinalCustomerSaleUseCase : IProductCustomerSaleUseCaseQuery
    {
        private readonly IProductRepository _productRepository;
        private readonly ISalesRepository _saleProductRepository;

        public QFinalCustomerSaleUseCase(IProductRepository repository, ISalesRepository saleProductRepository)
        {
        _productRepository = repository;
        _saleProductRepository = saleProductRepository;
        }

        public async Task<SaleResponse> RegisterProductFinalCustomerSale(string product)
        {
            RegisterSaleCommand customerSaleToCreate = JsonConvert.DeserializeObject<RegisterSaleCommand>(product);
            double totalPrice = 0;
            foreach (var item in customerSaleToCreate.Products)
            {
                var productResponse = await _productRepository.RegisterProductFinalCustomerSaleAsync(item);
                               

                var discount = productResponse.Price * 0.15;
                var price = (productResponse.Price - discount) * item.Quantity;
                totalPrice += price;                

            }

            var saleNumber = new SalesObjectNumber(customerSaleToCreate.Number);
            var saleQuantity = new SalesObjectQuantity(customerSaleToCreate.Products.Count);
            var saleTotal = new SalesObjectTotal(totalPrice);
            var saleType = new SalesObjectType("FinalCustomerSale");

            var saleEntity = new SalesEntity(saleNumber, saleQuantity, saleTotal, saleType, customerSaleToCreate.BranchId);
            var saleEntityResponse = await _saleProductRepository.RegisterSaleAsync(saleEntity);

            var saleResponse = new SaleResponse();
            saleResponse.Number = saleEntity.Number.Number;
            saleResponse.Quantity = saleEntity.Quantity.Quantity;
            saleResponse.Total = saleEntity.Total.Total;
            saleResponse.Type = saleEntity.Type.Type;
            saleResponse.BranchId = saleEntity.BranchId;
            saleEntity.SalesId = saleEntity.SalesId;          

            return saleResponse;
                      
        }

    }
}
