using Framework.DAL;
using System;
using System.Collections.Generic;

namespace Framework.Services.Security.Credentials
{
    public class UserParameterMapper : IParameterMapper<User, UserParameterMappings>
    {
        public User MapToEntity(Dictionary<string, object> data, UserParameterMappings type)
        {
            switch(type)
            {
                case UserParameterMappings.Retrieve:
                case UserParameterMappings.RetrieveByCredentials:
                    return MapToEntityRetrieve(data, type);
                default:
                    throw new ArgumentException("type");
            }
        }

        public Dictionary<string, object> MapToParameters(User data, UserParameterMappings type)
        {
            switch (type)
            {
                case UserParameterMappings.Create:
                case UserParameterMappings.Update:
                case UserParameterMappings.Delete:
                    return MapToParametersGeneric(data, type);
                default:
                    throw new ArgumentException("type");
            }
        }

        private User MapToEntityRetrieve(Dictionary<string, object> data, UserParameterMappings type)
        {
            User user = new User();
            user.Id = (long)data["id"];
            user.Name = (string)data["name"];
            user.Password = (string)data["password"];
            return user;
        }

        private Dictionary<string, object> MapToParametersGeneric(User data, UserParameterMappings type)
        {
            var ret = new Dictionary<string, object>
            {
                { "id", data.Id },
                { "name", data.Name },
                { "password", data.Password }
            };
            return ret;
        }
    }
}
