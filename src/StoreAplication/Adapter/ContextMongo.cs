using Adapter.Data;
using Adapter.Interfaces;
using MongoDB.Driver;

namespace Adapter
{
    public class ContextMongo : IContextMongo
    {
        private readonly IMongoDatabase _database;

        public ContextMongo(string stringConnection, string DBname)
        {
            MongoClient client = new MongoClient(stringConnection);
            _database = client.GetDatabase(DBname);
        }

        public IMongoCollection<StoredEventDTO> StoredEvent => _database.GetCollection<StoredEventDTO>("storedEvent");
    }

}

