using Framework.Services.Security.Credentials;

namespace Framework.Services.Security
{
    public class SessionManager
    {
        private IUserRetrieverByCredentials userRetriever;

        public SessionManager(IUserRetrieverByCredentials userRetriever)
        {
            this.userRetriever = userRetriever;
        }

        public IUser RetrieveByCredentials(string user, string password)
        {
            return userRetriever.RetrieveByCredentials(user, password);
        }
    }
}
