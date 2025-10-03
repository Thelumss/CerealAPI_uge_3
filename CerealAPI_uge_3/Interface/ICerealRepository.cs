using CerealAPI_uge_3.Models;
using Org.BouncyCastle.Asn1.X509;

namespace CerealAPI_uge_3.Interface
{
    public interface ICerealRepository
    {
        ICollection<Cereal> GetCereals();
        Cereal GetCerealById(int id);
        bool cerealExists(int id);
        bool deleteCerealByCereal(Cereal Cereal);
        Cereal getCerealbyName(string Name);
        ICollection<Cereal> getCerealByBrand(string Brands);
        ICollection<Cereal> getCerealbytemp(string Temperatur);
        ICollection<Cereal> getCerealbySugars(int sugars);
        bool createCereal(Cereal cereal);
        bool UpdateCereal(Cereal cereal);
        bool Save();

    }
}
