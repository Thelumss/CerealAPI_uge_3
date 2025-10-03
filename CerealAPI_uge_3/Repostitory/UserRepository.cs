using CerealAPI_uge_3.Data;
using CerealAPI_uge_3.Interface;
using CerealAPI_uge_3.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using NuGet.Common;
using System.Security.Cryptography;

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

        public Token login(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
