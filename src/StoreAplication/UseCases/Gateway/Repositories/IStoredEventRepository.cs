using Domain.Entities;

namespace UseCases.Gateway.Repositories
{
    public interface IStoredEventRepository
    {
        Task<String> RegisterEvent(StoredEventEntity storedEvent);
    }
}
