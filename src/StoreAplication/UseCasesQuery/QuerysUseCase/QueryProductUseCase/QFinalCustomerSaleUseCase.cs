using Domain.Commands.Product;
using Domain.Entities;
using Domain.ObjectValues.ObjectValuesSales;
using Domain.Response.Sale;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                if (productResponse.InventoryStock < item.Quantity)
                {
                    throw new Exception($"No hay suficiente stock para el producto: {productResponse.Name}");
                }

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
            saleResponse.BranchId = saleEntityResponse.BranchId;
            saleResponse.Number = saleEntityResponse.Number.Number;
            saleResponse.Quantity = saleEntityResponse.Quantity.Quantity;
            saleResponse.Total = saleEntityResponse.Total.Total;
            saleResponse.Type = saleEntityResponse.Type.Type;            
            saleResponse.SalesId = saleEntityResponse.SalesId;

            return saleResponse;
        }

    }
}
