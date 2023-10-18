using AdapterMongoDB.Data;
using AutoMapper;
using Domain.Entities;

namespace AdapterMongoDB.Common
{
    public class ProfileMongo : Profile
    {
        public ProfileMongo()
        {
            CreateMap<StoredEventDTO, StoredEventEntity>().ReverseMap();
        }
    }
}
