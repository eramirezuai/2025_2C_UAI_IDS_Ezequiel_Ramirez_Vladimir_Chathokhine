using Framework.DAL;
using Framework.Services.Security.Credentials;

namespace Framework.Services.Security
{
    public class SessionFactoryLoader
    {
        public static void LoadClasses()
        {
            SessionFactory.ConfigureType<IUser>(() => new User());
            SessionFactory.ConfigureType<IUserRetrieverByCredentials>(() => new UserCrud(new Access(), new UserParameterMapper()));
        }
    }
}
