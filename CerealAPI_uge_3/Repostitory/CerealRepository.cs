using CerealAPI_uge_3.Data;
using CerealAPI_uge_3.Interface;
using CerealAPI_uge_3.Models;

namespace CerealAPI_uge_3.Repostitory
{
    public class CerealRepository: ICerealRepository
    {
        private readonly CerealDataContext context;

        public CerealRepository(CerealDataContext context) 
        {
            this.context = context;
        }

        public ICollection<Cereal> GetCereals() {
            return context.cereals.OrderBy(x => x.Id).ToList();
        }
        public ICollection<Cereal> getCerealByBrand(string Brands)
        {
            return context.cereals.Where(x => x.Brands == Brands).ToList();
        }

        public ICollection<Cereal> getCerealbytemp(string Temperatur)
        {
            return context.cereals.Where(x => x.Temperatur == Temperatur).ToList();
        }

        public Cereal GetCerealById(int id)
        {
            return context.cereals.Where(x => x.Id == id).FirstOrDefault();
        }

        public Cereal getCerealbyName(string Name)
        {
            return context.cereals.Where(x => x.Name == Name).FirstOrDefault();
        }

        public ICollection<Cereal> getCerealbySugars(int sugars)
        {
            return context.cereals.Where(x => x.sugars == sugars).ToList();
        }
    }
}
