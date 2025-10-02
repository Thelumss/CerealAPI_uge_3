using CerealAPI_uge_3.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using CerealAPI_uge_3.Repositories.Models;
namespace CerealAPI_uge_3.Repositories
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CerealDataContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<CerealDataContext>>()))
            {
                if (!context.cereals.Any())
                {
                    context.AddRange(
                        new Cereal
                        {
                            Name = ""
                            
                        }
                        );

                }
            }
        }

    }
}
