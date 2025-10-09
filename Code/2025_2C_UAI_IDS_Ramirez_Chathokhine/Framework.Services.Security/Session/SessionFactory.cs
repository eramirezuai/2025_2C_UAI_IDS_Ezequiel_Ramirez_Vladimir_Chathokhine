using Framework.Services.Security.Credentials;
using System;
using System.Collections.Generic;
using InstanceCreator = System.Func<object>;

namespace Framework.Services.Security
{
    public class SessionFactory
    {
        private static SessionFactory instance;
        private Dictionary<Type, InstanceCreator> creators = new Dictionary<Type, InstanceCreator>();

        static SessionFactory()
        {
            SessionFactoryLoader.LoadClasses();
        }

        public static SessionFactory Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SessionFactory();
                }
                return instance;
            }
        }

        public static IUser CreateUser()
        {
            return Instance.CreateInstance<IUser>();
        }

        public static IUserRetrieverByCredentials CreateUserRetrieverByCredentials()
        {
            return Instance.CreateInstance<IUserRetrieverByCredentials>();
        }

        public static void ConfigureType<T>(InstanceCreator creator)
        {
            Instance.Configure<T>(creator);
        }

        public static void UnconfigureType<T>()
        {
            Instance.Unconfigure<T>();
        }

        private T CreateInstance<T>()
        {
            return (T) this.creators[typeof(T)]();
        }

        private void Configure<T>(InstanceCreator creator)
        {
            this.creators.Add(typeof(T), creator);
        }

        private void Unconfigure<T>()
        {
            this.creators.Remove(typeof(T));
        }
    }
}
