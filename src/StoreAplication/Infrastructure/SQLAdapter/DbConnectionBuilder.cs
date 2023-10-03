using Infrastructure.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SQLAdapter
{
    public class DbConnectionBuilder : DbContext
    {

        public DbConnectionBuilder(DbContextOptions<DbConnectionBuilder> options) : base(options)
        {
        }

        public DbSet<RegisterBranchDTO> Branch { get; set; }
        public DbSet<RegisterProductDTO> Product { get; set; }
        public DbSet<RegisterUserDTO> User { get; set; }


    }
}
