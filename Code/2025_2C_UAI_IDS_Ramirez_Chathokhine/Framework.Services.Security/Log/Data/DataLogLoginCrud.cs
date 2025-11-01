using System.Collections.Generic;
using Framework.DAL;

namespace Framework.Services.Security.Log
{
    public enum DataLogLoginParameterMappings
    {
        Create,
        Retrieve,
        Update,
        Delete
    }

    public class DataLogLoginCrud : EntityCrud<DataLogLoginEntry, DataLogLoginParameterMappings>
    {
        public DataLogLoginCrud(IAccess access, IParameterMapper<DataLogLoginEntry, DataLogLoginParameterMappings> parameterMapper) : base(access, parameterMapper, parameterMapper)
        {
        }

        public override void Create(DataLogLoginEntry data)
        {
            base.Create(data, DataLogLoginParameterMappings.Create, "log_login_insert");
        }

        public override void Delete(DataLogLoginEntry data)
        {
            base.Delete(data, DataLogLoginParameterMappings.Delete, "log_login_delete");
        }

        public override void Delete(DataLogLoginEntry data, Dictionary<string, object> args)
        {
            base.Delete(data, DataLogLoginParameterMappings.Delete, "log_login_delete");
        }

        public override IEnumerable<DataLogLoginEntry> Retrieve()
        {
            return base.Retrieve(DataLogLoginParameterMappings.Retrieve, "log_login_select_all");
        }

        public override IEnumerable<DataLogLoginEntry> Retrieve(Dictionary<string, object> args)
        {
            return base.Retrieve(args, DataLogLoginParameterMappings.Retrieve, "log_login_select_all");
        }

        public override void Update(DataLogLoginEntry data)
        {
            base.Update(data, DataLogLoginParameterMappings.Update, "log_login_update");
        }
    }
}