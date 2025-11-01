using Framework.Services.Security.Credentials;
using System;

namespace Framework.Services.Security.Log
{
    public interface IDataLogEntry
    {
        DateTime Date { get; set; }
        IUser User { get; set; }
    }
}