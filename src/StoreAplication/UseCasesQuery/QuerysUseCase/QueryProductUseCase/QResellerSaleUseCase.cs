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
    public class QResellerSaleUseCase : IProductResellerSaleUseCaseQuery
    {
        private readonly IProductRepository _productRepository;
        private readonly ISalesRepository _saleProductRepository;

        public QResellerSaleUseCase(IProductRepository repository, ISalesRepository saleRepository)
        {
            _productRepository = repository;
            _saleProductRepository = saleRepository;
        }

        public async Task<SaleResponse> RegisterResellerSale(string product)
        {
            RegisterSaleCommand ResellerSaleToCreate = JsonConvert.DeserializeObject<RegisterSaleCommand>(product);
            double totalPrice = 0;
            foreach (var item in ResellerSaleToCreate.Products)
            {
                var productResponse = await _productRepository.RegisterProductResellerSaleAsync(item);

                if (productResponse.InventoryStock < item.Quantity)
                {
                    throw new Exception($"No hay suficiente stock para el producto: {productResponse.Name}");
                }

                var discount = productResponse.Price * 0.25;
                var price = (productResponse.Price - discount) * item.Quantity;
                totalPrice += price;
            }

            var saleNumber = new SalesObjectNumber(ResellerSaleToCreate.Number);
            var saleQuantity = new SalesObjectQuantity(ResellerSaleToCreate.Products.Count);
            var saleTotal = new SalesObjectTotal(totalPrice);
            var saleType = new SalesObjectType("ResellerSale");

            var saleEntity = new SalesEntity(saleNumber, saleQuantity, saleType, saleTotal, ResellerSaleToCreate.BranchId); 
            var saleEntityResponse = await _saleProductRepository.RegisterSaleAsync(saleEntity);

            var saleResponse = new SaleResponse();
            saleResponse.BranchId = saleEntity.BranchId;
            saleResponse.Number = saleEntity.Number.Number;
            saleResponse.Quantity = saleEntity.Quantity.Quantity;
            saleResponse.Type = saleEntity.Type.Type;
            saleResponse.Total = saleEntity.Total.Total;
            saleResponse.SalesId = saleEntityResponse.SalesId;

            return saleResponse;
        }
    }
    
}
