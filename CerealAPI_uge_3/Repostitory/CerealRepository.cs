using CerealAPI_uge_3.Data;
using CerealAPI_uge_3.Interface;
using CerealAPI_uge_3.Models;

namespace CerealAPI_uge_3.Repostitory
{
    public class CerealRepository: ICereal
    {
        private readonly CerealDataContext context;

        public CerealRepository(CerealDataContext context) 
        {
            this.context = context;
        }

        public ICollection<Cereal> GetCereals() {
            return context.cereals.OrderBy(x => x.Id).ToList();
        }
    }
}
