using Framework.DAL;
using Framework.Services.Security.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services.Security.Log
{
    public class DataLogDatabaseParameterMapper : IParameterMapper<DataLogDatabaseEntry, DataLogDatabaseParameterMappings>
    {
        public DataLogDatabaseEntry MapToEntity(Dictionary<string, object> data, DataLogDatabaseParameterMappings type)
        {
            switch (type)
            {
                case DataLogDatabaseParameterMappings.Retrieve:
                    return MapToEntityRetrieve(data, type);
                default:
                    throw new ArgumentException("type");
            }
        }

        public Dictionary<string, object> MapToParameters(DataLogDatabaseEntry data, DataLogDatabaseParameterMappings type)
        {
            switch (type)
            {
                case DataLogDatabaseParameterMappings.Create:
                    return MapToParametersCreate(data, type);
                default:
                    throw new ArgumentException("type");
            }
        }

        private DataLogDatabaseEntry MapToEntityRetrieve(Dictionary<string, object> data, DataLogDatabaseParameterMappings type)
        {
            DataLogDatabaseEntry datalogDatabaseEntry = new DataLogDatabaseEntry();
            datalogDatabaseEntry.Id = (long)data["id"];
            datalogDatabaseEntry.Date = (DateTime)data["date"];
            datalogDatabaseEntry.User = new User()
            {
                Id = (long)data["user_id"],
                Name = (string)data["user_name"]
            };
            datalogDatabaseEntry.Operation = (DataLogDatabaseOperation)(int)data["operation"];
            datalogDatabaseEntry.Patent = new SinglePatent()
            {
                Id = (long)data["patent_id"],
                Code = (string)data["patent_code"],
                Description = (string)data["patent_description"]
            };
            return datalogDatabaseEntry;
        }

        private Dictionary<string, object> MapToParametersCreate(DataLogDatabaseEntry data, DataLogDatabaseParameterMappings type)
        {
            var ret = new Dictionary<string, object>
            {
                { "date", data.Date },
                { "user_id", data.User.Id },
                { "operation", (int)data.Operation },
                { "patent_id", data.Patent.Id }
            };
            return ret;
        }
    }
}
