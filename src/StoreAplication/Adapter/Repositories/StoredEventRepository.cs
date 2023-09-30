using Adapter.Data;
using Adapter.Interfaces;
using AutoMapper;
using Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories;

namespace Adapter.Repositories
{
    public class StoredEventRepository : IStoredEventRepository
    {
        private readonly IMongoCollection<StoredEventDTO> _storedEvents;
        private readonly IMapper _mapper;

        public StoredEventRepository(IContextMongo dbContextMongo, IMapper mapper)
        {
            _storedEvents = dbContextMongo.StoredEvent;
            _mapper = mapper;
        }

        public async Task<string> RegisterEvent(StoredEventEntity storedEvent)
        {
            var eventToRegister = _mapper.Map<StoredEventDTO>(storedEvent);
            await _storedEvents.InsertOneAsync(eventToRegister);
            return "Event Registered";
        }

       
    }
}
