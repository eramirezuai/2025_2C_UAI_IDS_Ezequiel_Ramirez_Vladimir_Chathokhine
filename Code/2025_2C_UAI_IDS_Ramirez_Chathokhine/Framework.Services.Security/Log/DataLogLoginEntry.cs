using System;
using Framework.Services.Security.Credentials;

namespace Framework.Services.Security.Log
{
    public class DataLogLoginEntry : DataLogEntry, IDataLogLoginEntry
    {
        public DataLogLoginOperation Operation { get; set; }

        public DataLogLoginEntry(DateTime date, User user, DataLogLoginOperation operation) : base(date, user)
        {
            this.Operation = operation;
        }

        public DataLogLoginEntry() : base(DateTime.Now, null)
        {

        }
    }
}
