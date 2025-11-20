using System.Collections.Generic;
using Framework.DAL;

namespace Framework.Services.Security.Log
{
    public enum DataLogDatabaseParameterMappings
    {
        Create,
        Retrieve,
        Update,
        Delete
    }

    public class DataLogDatabaseCrud : EntityCrud<DataLogDatabaseEntry, DataLogDatabaseParameterMappings>
    {
        public DataLogDatabaseCrud(IAccess access, IParameterMapper<DataLogDatabaseEntry, DataLogDatabaseParameterMappings> parameterMapper) : base(access, parameterMapper, parameterMapper)
        {
        }

        public override void Create(DataLogDatabaseEntry data)
        {
            base.Create(data, DataLogDatabaseParameterMappings.Create, "log_database_insert");
        }

        public override void Delete(DataLogDatabaseEntry data)
        {
            base.Delete(data, DataLogDatabaseParameterMappings.Delete, "log_database_delete");
        }

        public override void Delete(DataLogDatabaseEntry data, Dictionary<string, object> args)
        {
            base.Delete(data, DataLogDatabaseParameterMappings.Delete, "log_database_delete");
        }

        public override IEnumerable<DataLogDatabaseEntry> Retrieve()
        {
            return base.Retrieve(DataLogDatabaseParameterMappings.Retrieve, "log_database_select_all");
        }

        public override IEnumerable<DataLogDatabaseEntry> Retrieve(Dictionary<string, object> args)
        {
            return base.Retrieve(args, DataLogDatabaseParameterMappings.Retrieve, "log_database_select_all");
        }

        public override void Update(DataLogDatabaseEntry data)
        {
            base.Update(data, DataLogDatabaseParameterMappings.Update, "log_database_update");
        }
    }
}