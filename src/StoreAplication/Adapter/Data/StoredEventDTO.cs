using MongoDB.Bson.Serialization.Attributes;

namespace Adapter.Data
{
    public class StoredEventDTO
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string StoredId { get; set; }

        public string StoredName { get; set; }

        public string AggregateId { get; set; }

        public string EventBody { get; set; }
    }
}
