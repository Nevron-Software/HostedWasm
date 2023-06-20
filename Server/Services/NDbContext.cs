using HostedWasm.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace HostedWasm.Server.Services
{
    public class NDbContext : DbContext
    {
        #region Constructors


        public NDbContext(DbContextOptions<NDbContext> options)
            : base((DbContextOptions)(object)options)
        {

        }

        #endregion

        #region Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Continent>().ToTable("Continent");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
        }

        #endregion

        #region Properties

        public DbSet<Continent> Continents { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }


        #endregion
    }
}
