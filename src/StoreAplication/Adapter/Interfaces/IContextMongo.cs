using Adapter.Data;
using MongoDB.Driver;

namespace Adapter.Interfaces
{
    public interface IContextMongo
    {
        public IMongoCollection<StoredEventDTO> StoredEvent { get; }
    }
}

