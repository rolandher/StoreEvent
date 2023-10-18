using AdapterSQL.DTO;
using AutoMapper;
using Domain.Response.Branch;
using Domain.Response.Product;
using Domain.Response.Sale;
using Domain.Response.User;

namespace AdapterSQL.ConfigurationProfileSql
{
    public class ProfileSql : Profile

    {
        public ProfileSql()
        {
            CreateMap<RegisterBranchDTO, BranchQueryResponse>().ReverseMap();
            CreateMap<RegisterProductDTO, ProductResponse>().ReverseMap();
            CreateMap<RegisterUserDTO, UserQueryResponse>().ReverseMap();
            CreateMap<RegisterSalesDTO, SaleResponse>().ReverseMap();
        }

    }
}
