using CerealAPI_uge_3.Data;
using CerealAPI_uge_3.Interface;

namespace CerealAPI_uge_3.Repostitory
{
    public class AuthenticationRepository: IAuthenticationRepository
    {
        private readonly CerealDataContext context;

        public AuthenticationRepository(CerealDataContext context)
        {
            this.context = context;
        }

        public string token()
        {
            throw new NotImplementedException();
        }
    }
}
