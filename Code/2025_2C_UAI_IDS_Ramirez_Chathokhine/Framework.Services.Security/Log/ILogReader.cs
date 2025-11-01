using System.Collections.Generic;

namespace Framework.Services.Security.Log
{
    public interface ILogReader
    {
        IEnumerable<DataLogDatabaseEntry> GetDatabaseEntries();
        IEnumerable<DataLogLoginEntry> GetLoginEntries();
    }
}