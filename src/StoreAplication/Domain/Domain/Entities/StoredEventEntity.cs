namespace Domain.Entities
{
    public class StoredEventEntity
    {
        public string StoredName { get; set; }
        public Guid AggregateId { get; set; }

        public string EventBody { get; set; }

        public StoredEventEntity()
        {

        }
        public StoredEventEntity(string storedName, Guid aggregateId, string eventBody)
        {
            StoredName = storedName;
            AggregateId = aggregateId;
            EventBody = eventBody;
        }

    }
}
