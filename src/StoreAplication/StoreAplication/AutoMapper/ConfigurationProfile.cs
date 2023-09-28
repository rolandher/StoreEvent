using AutoMapper;
using Domain.Commands.Branch;
using Domain.Commands.Product;
using Domain.Commands.User;
using Domain.Entities;

namespace StoreAplication.AutoMapper
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<RegisterUser, Users>().ReverseMap();
            CreateMap<RegisterProduct, Products>().ReverseMap();
            CreateMap<RegisterBranch, Branchs>().ReverseMap();

        }
    }
}

