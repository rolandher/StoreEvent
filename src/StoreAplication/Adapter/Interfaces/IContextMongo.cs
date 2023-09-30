using Adapter.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Interfaces
{
    public interface IContextMongo
    {
        public IMongoCollection<StoredEventDTO> StoredEvent { get; }
    }
}

