using Framework.DAL;
using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Framework.Services.Security.Credentials.Data
{
    public class PatentParameterMapper : IParameterMapper<Patent, PatentParameterMappings>
    {

        public Patent MapToEntity(Dictionary<string, object> data, PatentParameterMappings type)
        {
            switch (type)
            {
                case PatentParameterMappings.RetrieveByParent:
                case PatentParameterMappings.Retrieve:
                    return MapToEntityRetrieve(data, type);
                default:
                    throw new ArgumentException("type");
            }
        }

        public Dictionary<string, object> MapToParameters(Patent data, PatentParameterMappings type)
        {
            switch (type)
            {
                //case PatentParameterMappings.Create:
                //case PatentParameterMappings.Update:
                //    return MapToParametersGeneric(data, type);
                //case PatentParameterMappings.Delete:
                //    return MapToParametersDelete(data, type);
                default:
                    throw new ArgumentException("type");
            }
        }

        private Patent MapToEntityRetrieve(Dictionary<string, object> data, PatentParameterMappings type)
        {
            SinglePatent patent = new SinglePatent();
            //Patent patent = new Patent();
            patent.Id = (long)data["id"];
            patent.Code = (string)data["code"];
            patent.Description = (string)data["description"];


            return patent;
        }

        private Dictionary<string, object> MapToParametersGeneric(Patent data, PatentParameterMappings type)
        {
            var ret = new Dictionary<string, object>
            {
                //{ "@name", data.Name },
                //{ "@password", data.Password }
            };
            return ret;
        }

        private Dictionary<string, object> MapToParametersDelete(Patent data, PatentParameterMappings type)
        {
            var ret = new Dictionary<string, object>
            {
                //{ "@id", data.Id },
            };
            return ret;
        }
    }
}
