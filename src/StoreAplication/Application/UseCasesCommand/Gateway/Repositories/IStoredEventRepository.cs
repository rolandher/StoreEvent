using Domain.Entities;

namespace UseCasesCommand.Gateway.Repositories
{
    public interface IStoredEventRepository
    {
        Task<string> RegisterEvent(StoredEventEntity storedEvent);
    }
}
