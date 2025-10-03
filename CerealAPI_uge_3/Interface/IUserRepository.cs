using CerealAPI_uge_3.Models;
using NuGet.Common;

namespace CerealAPI_uge_3.Interface
{
    //the beginings of interface for UserRepository for autrzation
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        bool createUser(User user);
        bool UserExists(int id);

        Token login(string name, string password);
    }
}
