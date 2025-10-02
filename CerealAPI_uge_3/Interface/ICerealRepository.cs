using CerealAPI_uge_3.Models;

namespace CerealAPI_uge_3.Interface
{
    public interface ICerealRepository
    {
        ICollection<Cereal> GetCereals();
        Cereal GetCerealById(int id);
        Cereal getCerealbyName(string Name);
        ICollection<Cereal> getCerealByBrand(string Brands);
        ICollection<Cereal> getCerealbytemp(string Temperatur);
        ICollection<Cereal> getCerealbySugars(int sugars);

    }
}
