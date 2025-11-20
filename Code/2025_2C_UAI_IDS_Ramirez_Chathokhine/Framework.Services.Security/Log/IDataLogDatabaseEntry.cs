using Framework.Services.Security.Credentials;

namespace Framework.Services.Security.Log
{
    public interface IDataLogDatabaseEntry : IDataLogEntry
    {
        DataLogDatabaseOperation Operation { get; set; }
        IPatent Patent { get; set; }
    }
}