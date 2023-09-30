using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories;

namespace Infrastructure.SQLAdapter.Repositories
{
    public class StoredEventRepository : IStoredEventRepository
    {
        public Task<string> RegisterEvent(StoredEventEntity storedEvent)
        {
            throw new NotImplementedException();
        }
    }
}
