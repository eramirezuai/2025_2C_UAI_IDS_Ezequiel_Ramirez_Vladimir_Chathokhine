namespace Framework.Services.Security.Log
{
    public interface ILogWriter
    {
        void WriteLoginEntry(DataLogLoginEntry entry);
        void WriteOperationEntry(DataLogDatabaseEntry entry);
    }
}