using Framework.DAL;
using System;
using System.Collections.Generic;

namespace Framework.Services.Security.Log
{
    public class DatabaseLogReader : ILogReader
    {
        private IRetriever<DataLogLoginEntry> dataLogLoginRetriever;
        private IRetriever<DataLogDatabaseEntry> dataLogDatabaseRetriever;

        public DatabaseLogReader(IRetriever<DataLogLoginEntry> dataLogLoginRetriever, IRetriever<DataLogDatabaseEntry> dataLogDatabaseRetriever)
        {
            this.dataLogDatabaseRetriever = dataLogDatabaseRetriever;
            this.dataLogLoginRetriever = dataLogLoginRetriever;
        }

        public IEnumerable<DataLogLoginEntry> GetLoginEntries()
        {
            return dataLogLoginRetriever.Retrieve();
        }

        public IEnumerable<DataLogDatabaseEntry> GetDatabaseEntries()
        {
            return dataLogDatabaseRetriever.Retrieve();
        }
    }
}
