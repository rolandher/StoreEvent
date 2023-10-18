using Domain.Entities;

namespace UseCasesCommand.Gateway.Repositories
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
