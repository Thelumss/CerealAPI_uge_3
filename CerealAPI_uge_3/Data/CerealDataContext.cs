using CerealAPI_uge_3.Models;
using Microsoft.EntityFrameworkCore;

namespace CerealAPI_uge_3.Data
{
    public class CerealDataContext: DbContext
    {
        // Simple to create a context for getting to the database
        public CerealDataContext(DbContextOptions<CerealDataContext> options)
            : base(options) 
        {
            
        }

        //Each of these represents a table in the database
        public DbSet<Cereal> cereals { get; set; }

        public DbSet<User> users { get; set; }

    }
}
