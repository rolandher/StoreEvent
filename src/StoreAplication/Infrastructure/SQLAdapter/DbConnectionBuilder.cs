using Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<RegisterSalesDTO> Sale { get; set; }






    }
}
