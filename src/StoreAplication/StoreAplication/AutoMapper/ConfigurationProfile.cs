using AutoMapper;

namespace StoreAplication.AutoMapper
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<NewUser, User>().ReverseMap();
            CreateMap<NewBranch, Branch>().ReverseMap();
            CreateMap<NewProduct, Product>().ReverseMap();

        }
    }
}

