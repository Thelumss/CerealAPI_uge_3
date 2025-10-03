using CerealAPI_uge_3.Data;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Security.Policy;
namespace CerealAPI_uge_3.Models
{
    public class SeedData
    {

        //seeding the database with data
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            //first setting up the database connection
            using (var context = new CerealDataContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<CerealDataContext>>()))
            {
                //her i check i there is any thing in the table cereals if not we fill it up with information from the csv file
                if (!context.cereals.Any())
                {
                    // the path to the csv file 
                    string path = @"..\..\..\Cereal.csv";
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string currentline;
                        int number = 0;
                        while ((currentline = sr.ReadLine()) != null)
                        {
                            //this is here becuse the first 2 lines of the csv is not data to the table and thus have to be ingored 
                            if (number <= 1)
                            {
                                number++;
                            }
                            else 
                            {
                                // it is very simple and would break if more collums were add but it just goes trough the csv file line by line spliting the string by semicolon and putting it a cereal that has each field
                                string[] input = currentline.Split(';');
                                context.AddRange(
                                     new Cereal
                                     {
                                         Name = input[0],
                                         Brands = input[1],
                                         Temperatur = input[2],
                                         Calories = int.Parse(input[3]),
                                         Protein = int.Parse(input[4]),
                                         Fat = int.Parse(input[5]),
                                         Sodium = int.Parse(input[6]),
                                         Fiber = float.Parse(input[7]),
                                         Carbo = float.Parse(input[8]),
                                         sugars = int.Parse(input[9]),
                                         Potass = int.Parse(input[10]),
                                         vitamins = int.Parse(input[11]),
                                         Shelf = int.Parse(input[12]),
                                         Weight = float.Parse(input[13]),
                                         Cups = float.Parse(input[14]),
                                         Rating = float.Parse(input[15])
                                     }
                                     );
                            }
                            // her we close the csv file
                            sr.Close();
                        }
                    }

                }


                //the beginings for autrzation of with password hashing and what not
                if (!context.users.Any())
                {
                    byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
                    context.AddRange(
                        new User
                        {
                            Name = "test",
                            Email = "test@test",
                            Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: "test",
                            salt: salt,
                            prf: KeyDerivationPrf.HMACSHA256,
                            iterationCount: 100000,
                            numBytesRequested: 256 / 8))
                        }
                        );
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
