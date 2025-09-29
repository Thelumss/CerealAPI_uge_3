using CerealAPI_uge_3.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace CerealAPI_uge_3.Repositories.Data
{
    public class CerealDataContext: DbContext
    {
        public CerealDataContext(DbContextOptions<CerealDataContext> options)
            : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cereal> cereals { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Temperatur> temperaturs { get; set; }

    }
}
