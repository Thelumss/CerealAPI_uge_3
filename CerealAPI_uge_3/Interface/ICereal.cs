using CerealAPI_uge_3.Models;

namespace CerealAPI_uge_3.Interface
{
    public interface ICereal
    {
        ICollection<Cereal> GetCereals();
    }
}
