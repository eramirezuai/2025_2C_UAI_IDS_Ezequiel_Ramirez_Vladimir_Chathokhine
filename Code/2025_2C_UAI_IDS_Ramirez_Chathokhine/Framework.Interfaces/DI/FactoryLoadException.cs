using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DI
{
    public class FactoryLoadException : Exception
    {
        private const string _message = "Couldn't load classes for loader of type {0}";

        public Type Type { get; private set; }

        public FactoryLoadException(Type type) : base(_message)
        { 
            this.Type = type;
        }

        public FactoryLoadException(Type type, Exception exception) : base(_message, exception)
        {
            this.Type = type;
        }
    }
}
