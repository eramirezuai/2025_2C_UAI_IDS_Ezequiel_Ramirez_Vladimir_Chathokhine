using System.Linq;
using System.Collections.Generic;
using Framework.DAL;

namespace Framework.Services.Security.Credentials
{
    public enum UserParameterMappings
    {
        Create,
        Retrieve,
        RetrieveByCredentials,
        Update,
        Delete
    }

    public class UserCrud : EntityCrud<User, UserParameterMappings>, IUserRetrieverByCredentials
    {
        public UserCrud(IAccess access, IParameterMapper<User, UserParameterMappings> parameterMapper) : base(access, parameterMapper, parameterMapper)
        {
        }

        public override void Create(User data)
        {
            base.Create(data, UserParameterMappings.Create, "sp_user_insert");
        }

        public override void Delete(User data)
        {
            base.Delete(data, UserParameterMappings.Delete, "sp_user_delete");
        }

        public override void Delete(User data, Dictionary<string, object> args)
        {
            base.Delete(data, UserParameterMappings.Delete, "sp_user_delete");
        }

        public override IEnumerable<User> Retrieve()
        {
            return base.Retrieve(UserParameterMappings.Retrieve, "sp_user_select_all");
        }

        public override IEnumerable<User> Retrieve(Dictionary<string, object> args)
        {
            return base.Retrieve(UserParameterMappings.Retrieve, "sp_user_select_all");
        }

        public override void Update(User data)
        {
            base.Update(data, UserParameterMappings.Update, "sp_user_update");
        }

        public User RetrieveByCredentials(User user)
        {
            return RetrieveByCredentials(user.Name, user.Password);
        }

        public User RetrieveByCredentials(string user, string password)
        {
            var parameters = new Dictionary<string, object>()
            {
                {"@name",user},
                {"@password",password}
            };
            return base.Retrieve(parameters, UserParameterMappings.RetrieveByCredentials, "sp_user_select_by_credentials").FirstOrDefault();
        }

        IUser IUserRetrieverByCredentials.RetrieveByCredentials(string user, string password)
        {
            return RetrieveByCredentials(user, password);
        }
    }
}