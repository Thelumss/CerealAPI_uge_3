using CerealAPI_uge_3.Models;

namespace CerealAPI_uge_3.Interface
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        bool createUser(User user);
        bool UserExists(int id);
    }
}
