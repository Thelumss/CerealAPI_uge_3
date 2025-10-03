using CerealAPI_uge_3.Data;
using CerealAPI_uge_3.Interface;
using CerealAPI_uge_3.Models;

namespace CerealAPI_uge_3.Repostitory
{
    public class UserRepository : IUserRepository
    {
        private readonly CerealDataContext context;

        public UserRepository(CerealDataContext Context)
        {
            context = Context;
        }
        public bool createUser(User user)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetUsers()
        {
            return context.users.OrderBy(x => x.Id).ToList();
        }

        public bool UserExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
