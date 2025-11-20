using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Framework.Services.Security.Credentials;

namespace Framework.Services.Security.Log
{
    public class DataLog : IDataLog
    {
        private ILogWriter writer;
        private ILogReader reader;

        public DataLog(ILogReader reader, ILogWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void AddDatabaseEntry(DateTime date, User user, DataLogDatabaseOperation operation, Patent patent)
        {
            var entry = new DataLogDatabaseEntry(date, user, operation, patent);
            writer.WriteOperationEntry(entry);
        }

        public void AddLoginEntry(DateTime date, User user, DataLogLoginOperation operation)
        {
            var entry = new DataLogLoginEntry(date, user, operation);
            writer.WriteLoginEntry(entry);
        }

        public IEnumerable<DataLogDatabaseEntry> GetDatabaseEntries()
        {
            return reader.GetDatabaseEntries();
        }

        public IEnumerable<DataLogLoginEntry> GetLoginEntries()
        {
            return reader.GetLoginEntries();
        }

        void IDataLog.AddDatabaseEntry(DateTime date, IUser user, DataLogDatabaseOperation operation, IPatent patent)
        {
            AddDatabaseEntry(date, user as User, operation, patent as Patent);
        }

        void IDataLog.AddLoginEntry(DateTime date, IUser user, DataLogLoginOperation operation)
        {
            AddLoginEntry(date, user as User, operation);
        }

        IEnumerable<IDataLogDatabaseEntry> IDataLog.GetDatabaseEntries()
        {
            return GetDatabaseEntries();
        }

        IEnumerable<IDataLogLoginEntry> IDataLog.GetLoginEntries()
        {
            return GetLoginEntries();
        }
    }
}
