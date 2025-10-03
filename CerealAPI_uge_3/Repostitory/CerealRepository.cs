using CerealAPI_uge_3.Data;
using CerealAPI_uge_3.Interface;
using CerealAPI_uge_3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CerealAPI_uge_3.Repostitory
{
    public class CerealRepository : ICerealRepository
    {
        private readonly CerealDataContext context;

        public CerealRepository(CerealDataContext context) 
        {
            this.context = context;
        }

        // gets all of the cereals
        public ICollection<Cereal> GetCereals() {
            return context.cereals.OrderBy(x => x.Id).ToList();
        }
        // gets all of the cereals by a specifed brand
        public ICollection<Cereal> getCerealByBrand(string Brands)
        {
            return context.cereals.Where(x => x.Brands == Brands).ToList();
        }

        // gets all of the cereals by a specifed Temperatur
        public ICollection<Cereal> getCerealbytemp(string Temperatur)
        {
            return context.cereals.Where(x => x.Temperatur == Temperatur).ToList();
        }


        // gets all of the cereals by a specifed Id
        public Cereal GetCerealById(int id)
        {
            return context.cereals.Where(x => x.Id == id).FirstOrDefault();
        }

        // gets all of the cereals by a specifed name
        public Cereal getCerealbyName(string Name)
        {
            return context.cereals.Where(x => x.Name == Name).FirstOrDefault();
        }

        // gets all of the cereals by a specifed Sugar containt
        public ICollection<Cereal> getCerealbySugars(int sugars)
        {
            return context.cereals.Where(x => x.sugars == sugars).ToList();
        }

        // Deletes a cereal
        public bool deleteCerealByCereal(Cereal cereal)
        {
            context.Remove(cereal);
            
            return Save();
        }

        // checks if Cereal exists by its id
        public bool cerealExists(int id)
        {
            return context.cereals.Any(x => x.Id == id);
        }

        //saves changes made to the database
        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }

        // creates a Cereal
        public bool createCereal(Cereal cereal)
        {
            context.cereals.Add(cereal);
            return Save();
        }

        // Update a cereal cereal 
        public bool UpdateCereal(Cereal cereal)
        {
            context.cereals.Update(cereal);
            return Save();
        }
    }
}
