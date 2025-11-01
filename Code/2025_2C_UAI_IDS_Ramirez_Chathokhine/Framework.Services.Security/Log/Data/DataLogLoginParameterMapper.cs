using Framework.DAL;
using Framework.Services.Security.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services.Security.Log
{
    public class DataLogLoginParameterMapper : IParameterMapper<DataLogLoginEntry, DataLogLoginParameterMappings>
    {
        public DataLogLoginEntry MapToEntity(Dictionary<string, object> data, DataLogLoginParameterMappings type)
        {
            switch (type)
            {
                case DataLogLoginParameterMappings.Retrieve:
                    return MapToEntityRetrieve(data, type);
                default:
                    throw new ArgumentException("type");
            }
        }

        public Dictionary<string, object> MapToParameters(DataLogLoginEntry data, DataLogLoginParameterMappings type)
        {
            switch (type)
            {
                case DataLogLoginParameterMappings.Create:
                    return MapToParametersCreate(data, type);
                default:
                    throw new ArgumentException("type");
            }
        }

        private DataLogLoginEntry MapToEntityRetrieve(Dictionary<string, object> data, DataLogLoginParameterMappings type)
        {
            DataLogLoginEntry datalogDatabaseEntry = new DataLogLoginEntry();
            datalogDatabaseEntry.Id = (long)data["id"];
            datalogDatabaseEntry.Date = (DateTime)data["date"];
            datalogDatabaseEntry.User = new User()
            {
                Id = (long)data["user_id"],
                Name = (string)data["user_name"]
            };
            datalogDatabaseEntry.Operation = (DataLogLoginOperation)(int)data["operation"];
            return datalogDatabaseEntry;
        }

        private Dictionary<string, object> MapToParametersCreate(DataLogLoginEntry data, DataLogLoginParameterMappings type)
        {
            var ret = new Dictionary<string, object>
            {
                { "date", data.Date },
                { "user_id", data.User.Id },
                { "operation", (int)data.Operation }
            };
            return ret;
        }
    }
}
