using System.Collections.Generic;

namespace Framework.DAL
{
    public interface IDeleter<T>
    {
        void Delete(T data);
        void Delete(T data, Dictionary<string, object> args);
    }
}