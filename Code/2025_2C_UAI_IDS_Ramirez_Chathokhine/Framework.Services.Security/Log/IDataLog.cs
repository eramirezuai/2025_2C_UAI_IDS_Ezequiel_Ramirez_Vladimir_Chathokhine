using Framework.Services.Security.Credentials;
using System;
using System.Collections.Generic;

namespace Framework.Services.Security.Log
{
    public interface IDataLog
    {
        void AddDatabaseEntry(DateTime date, IUser user, DataLogDatabaseOperation operation, IPatent patent);
        void AddLoginEntry(DateTime date, IUser user, DataLogLoginOperation operation);
        IEnumerable<IDataLogDatabaseEntry> GetDatabaseEntries();
        IEnumerable<IDataLogLoginEntry> GetLoginEntries();
    }
}