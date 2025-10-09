using Framework.DAL;
using Framework.Services.Security.Credentials;
using Framework.Services.Security.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services.Security
{
    public class Session
    {
        private static Session currentInstance;

        private SessionManager sessionManager;

        public Session(SessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        public static bool OpenWith(IUser user, IUserRetrieverByCredentials retriever)
        {
            currentInstance = new Session(new SessionManager(retriever));
            return currentInstance.OpenWithInternal(user.Name, user.Password);
        }

        public static bool IsActive => currentInstance != null;

        public static Session Current => currentInstance;

        public virtual bool OpenWithInternal(string username, string password)
        {
            var user = this.Login(username, password);
            if (user == null)
                return false;
            User = user;
            return true;
        }

        public static void Close()
        {
            Current.CloseInternal();
            currentInstance = null;
        }

        private bool CloseInternal()
        {
            // TODO: Add login audit
            return true;
        }

        public IUser User { get; protected set; }

        private IUser Login(string username, string password)
        {
            return sessionManager.RetrieveByCredentials(
                username,
                password
            );
        }
    }
}