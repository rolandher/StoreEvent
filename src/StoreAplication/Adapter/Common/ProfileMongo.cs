using Adapter.Data;
using AutoMapper;
using Domain.Entities;

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
