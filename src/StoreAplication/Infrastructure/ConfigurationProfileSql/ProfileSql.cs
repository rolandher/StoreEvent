using AutoMapper;
using Domain.Response.Product;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
