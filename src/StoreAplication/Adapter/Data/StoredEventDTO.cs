using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Data
{
    public class StoredEventDTO
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string StoredId { get; set; }

        public string StoredName { get; set; }

        public int AggregateId { get; set; }

        public string EventBody { get; set; }
    }
}
