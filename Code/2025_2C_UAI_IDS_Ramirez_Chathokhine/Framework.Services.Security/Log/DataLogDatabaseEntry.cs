using Framework.Services.Security.Credentials;
using System;

namespace Framework.Services.Security.Log
{
    public class DataLogDatabaseEntry : DataLogEntry, IDataLogDatabaseEntry
    {
        public DataLogDatabaseOperation Operation { get; set; }
        public Patent Patent { get; set; }
        IPatent IDataLogDatabaseEntry.Patent { get => this.Patent; set => this.Patent = value as Patent; }

        public DataLogDatabaseEntry(DateTime date, User user, DataLogDatabaseOperation operation, Patent patent) : base(date, user)
        {
            this.Operation = operation;
            this.Patent = patent;
        }

        public DataLogDatabaseEntry() : base(DateTime.Now, null)
        {

        }
    }
}
