using AutoMapper;
using Domain.Response.Branch;
using Domain.Response.Product;
using Domain.Response.Sale;
using Domain.Response.User;
using Infrastructure.DTO;

namespace Infrastructure.ConfigurationProfileSql
{
    public class ProfileSql : Profile

    {
        public ProfileSql()
        {
            CreateMap<RegisterProductDTO, ProductResponse>().ReverseMap();
            CreateMap<RegisterBranchDTO, BranchQueryResponse>().ReverseMap();
            CreateMap<RegisterUserDTO, UserQueryResponse>().ReverseMap();
            CreateMap<RegisterSalesDTO, SaleResponse>().ReverseMap();
        }

    }
}
