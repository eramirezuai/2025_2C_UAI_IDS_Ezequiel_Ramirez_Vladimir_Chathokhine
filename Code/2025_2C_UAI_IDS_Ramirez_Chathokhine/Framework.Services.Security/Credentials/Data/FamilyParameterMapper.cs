using Framework.DAL;
using System;
using System.Collections.Generic;

namespace Framework.Services.Security.Credentials
{
    public class FamilyParameterMapper : IParameterMapper<Family, FamilyParameterMappings>
    {
        /// <summary>
        /// Mapea una fila de un dataset que proviene de una base de datos(SP) a un objeto de tipo Family
        /// </summary>
        /// <param name="data">Datos obtenidos de la BD</param>
        /// <param name="type">Tipo de operacion a mapear(Create,Retrieve,Update,Delete,RetrieveByUser)</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Family MapToEntity(Dictionary<string, object> data, FamilyParameterMappings type)
        {
            switch (type)
            {
                //case FamilyParameterMappings.Retrieve:
                //    return MapToEntityRetrieve(data, type);
                case FamilyParameterMappings.RetrieveByUser:
                    return MapToEntityRetrieve(data, type);
                case FamilyParameterMappings.RetrieveByFamily:
                    return MapToEntityRetrieve(data, type);
                default:
                    throw new ArgumentException("type");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Dictionary<string, object> MapToParameters(Family data, FamilyParameterMappings type)
        {
            switch (type)
            {
                //case FamilyParameterMappings.Create:
                //case FamilyParameterMappings.Update:
                //    return MapToParametersGeneric(data, type);
                //case FamilyParameterMappings.Delete:
                //    return MapToParametersDelete(data, type);

                default:
                    throw new ArgumentException("type");
            }
        }

        private Family MapToEntityRetrieve(Dictionary<string, object> data, FamilyParameterMappings type)
        {
            Family family = new Family((long)data["id"], (string)data["code"], (string)data["description"]);
            return family;
        }

        private Dictionary<string, object> MapToParametersGeneric(Family data, FamilyParameterMappings type)
        {
            var ret = new Dictionary<string, object>
            {
                //{ "@name", data.Name },
                //{ "@password", data.Password }
            };
            return ret;
        }

        private Dictionary<string, object> MapToParametersDelete(Family data, FamilyParameterMappings type)
        {
            var ret = new Dictionary<string, object>
            {
                { "@id", data.Id },
            };
            return ret;
        }
    }
}
