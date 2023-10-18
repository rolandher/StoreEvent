using AdapterMongoDB.Data;
using MongoDB.Driver;

namespace AdapterMongoDB.Interfaces
{
    public interface IContextMongo
    {
        public IMongoCollection<StoredEventDTO> StoredEvent { get; }
    }
}

