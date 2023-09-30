using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateway.Repositories
{
    public interface IStoredEventRepository
    {
        Task<String> RegisterEvent(StoredEventEntity storedEvent);
    }
}
