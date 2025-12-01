using CerealAPI_uge_3.Models;
using NuGet.Common;

namespace CerealAPI_uge_3.Interface
{
    //the beginnings of interface for UserRepository for authorization
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        bool createUser(User user);
        bool UserExists(int id);

        Token login(string name, string password);
    }
}
