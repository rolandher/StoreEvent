using Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.SQLAdapter
{
    public class DbConnectionBuilder : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbConnectionBuilder(DbContextOptions<DbConnectionBuilder> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-903KEOK;Database=StoreEventApi;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        public DbSet<RegisterBranchDTO> Branch { get; set; }
        public DbSet<RegisterProductDTO> Product { get; set; }
        public DbSet<RegisterUserDTO> User { get; set; }

        public DbSet<RegisterSalesDTO> Sale { get; set; }






    }
}
