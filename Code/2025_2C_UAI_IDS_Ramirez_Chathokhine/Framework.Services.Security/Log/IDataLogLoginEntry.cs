namespace Framework.Services.Security.Log
{
    public interface IDataLogLoginEntry : IDataLogEntry
    {
        DataLogLoginOperation Operation { get; set; }
    }
}