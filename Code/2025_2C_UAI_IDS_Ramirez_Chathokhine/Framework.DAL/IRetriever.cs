using System.Collections.Generic;

namespace Framework.DAL
{
    public interface IRetriever<out T>
    {
        IEnumerable<T> Retrieve();
        IEnumerable<T> Retrieve(Dictionary<string, object> args);
    }
}