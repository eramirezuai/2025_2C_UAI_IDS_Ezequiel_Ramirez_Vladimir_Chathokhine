using System;
using Framework.Services.Security.Credentials;

namespace Framework.Services.Security.Log
{
    public abstract class DataLogEntry : IDataLogEntry
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        IUser IDataLogEntry.User { get => this.User; set => this.User = value as User; }

        protected DataLogEntry(DateTime date, User user)
        {
            this.Date = date;
            this.User = user;
        }
    }
}
