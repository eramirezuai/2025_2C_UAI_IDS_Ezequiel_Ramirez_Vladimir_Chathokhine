using Framework.DAL;

namespace Framework.Services.Security.Log
{
    public class DatabaseLogWriter : ILogWriter
    {
        private ICreator<DataLogLoginEntry> dataLogLoginCreator;
        private ICreator<DataLogDatabaseEntry> dataLogDatabaseCreator;

        public DatabaseLogWriter(ICreator<DataLogLoginEntry> dataLogLoginCreator, ICreator<DataLogDatabaseEntry> dataLogDatabaseCreator)
        {
            this.dataLogLoginCreator = dataLogLoginCreator;
            this.dataLogDatabaseCreator = dataLogDatabaseCreator;
        }

        public void WriteLoginEntry(DataLogLoginEntry entry)
        {
            dataLogLoginCreator.Create(entry);
        }

        public void WriteOperationEntry(DataLogDatabaseEntry entry)
        {
            dataLogDatabaseCreator.Create(entry);
        }
    }
}
