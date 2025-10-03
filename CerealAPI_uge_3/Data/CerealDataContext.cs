using CerealAPI_uge_3.Models;
using Microsoft.EntityFrameworkCore;

namespace CerealAPI_uge_3.Data
{
    public class CerealDataContext: DbContext
    {
        public CerealDataContext(DbContextOptions<CerealDataContext> options)
            : base(options) 
        {
            
        }

     

        public DbSet<Cereal> cereals { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Temperatur> temperaturs { get; set; }
        public DbSet<User> users { get; set; }

    }
}
