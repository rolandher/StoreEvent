using Adapter.Data;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Common
{
    public class ProfileMongo : Profile
    {
        public ProfileMongo()
        {
            CreateMap<StoredEventDTO, StoredEventEntity>().ReverseMap();
        }
    }
}
