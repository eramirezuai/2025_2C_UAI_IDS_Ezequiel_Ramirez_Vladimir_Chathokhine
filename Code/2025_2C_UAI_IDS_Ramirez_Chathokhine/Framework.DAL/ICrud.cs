using System.Collections.Generic;

namespace Framework.DAL
{
    public interface ICrud<T> : IRetriever<T>, ICreator<T>, IUpdater<T>, IDeleter<T>
    {
    }
}