using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StoredEventEntity
    {
        public string StoredName { get; set; }
        public int AggregateId { get; set; }

        public string EventBody { get; set; }

        public StoredEventEntity()
        {

        }
        public StoredEventEntity(string storedName, int aggregateId, string eventBody)
        {
            StoredName = storedName;
            AggregateId = aggregateId;
            EventBody = eventBody;
        }

    }
}
