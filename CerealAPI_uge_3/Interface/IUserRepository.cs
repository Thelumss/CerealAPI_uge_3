using CerealAPI_uge_3.Models;
using NuGet.Common;

namespace CerealAPI_uge_3.Interface
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        bool createUser(User user);
        bool UserExists(int id);

        Token login(string name, string password);
    }
}
