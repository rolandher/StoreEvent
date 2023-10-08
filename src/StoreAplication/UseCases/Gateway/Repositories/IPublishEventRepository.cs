using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateway.Repositories
{
    public interface IPublishEventRepository
    {
        void PublishRegisterBranchEvent(StoredEventEntity eventToPublished);
        void PublishRegisterProduct(StoredEventEntity eventToPublished);
        void PublishRegisterProductSaleCustomer(StoredEventEntity eventToPublished);
        void PublishRegisterProductSaleReseller(StoredEventEntity eventToPublished);
        void PublishRegisterProductInvetoryStock(StoredEventEntity eventToPublished);
        void PublishRegisterUser(StoredEventEntity eventToPublished);
    }
}
