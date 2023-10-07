using AutoMapper;
using Domain.Response.Product;
using Infrastructure.DTO;

namespace Infrastructure.ConfigurationProfileSql
{
    public class ProfileSql : Profile

    {
        public ProfileSql()
        {
            CreateMap<RegisterProductDTO, ProductResponse>().ReverseMap();
        }

    }
}
