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
    public class MappingProfileMongo : Profile
    {
        public MappingProfileMongo()
        {
            CreateMap<StoredEventDTO, StoredEventEntity>().ReverseMap();
        }
    }
}
