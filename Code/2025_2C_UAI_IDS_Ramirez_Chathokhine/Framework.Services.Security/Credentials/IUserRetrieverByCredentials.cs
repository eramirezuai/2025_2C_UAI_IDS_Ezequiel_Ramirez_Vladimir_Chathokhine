using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services.Security.Credentials
{
    public interface IUserRetrieverByCredentials
    {
        IUser RetrieveByCredentials(string user, string password);
    }
}
