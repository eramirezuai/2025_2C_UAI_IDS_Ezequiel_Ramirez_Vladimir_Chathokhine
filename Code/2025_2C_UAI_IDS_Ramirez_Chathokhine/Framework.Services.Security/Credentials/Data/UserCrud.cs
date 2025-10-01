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

    public class UserCrud : EntityCrud<User, UserParameterMappings>
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

        User RetrieveByCredentials(string user, string password)
        {
            return base.Retrieve(UserParameterMappings.RetrieveByCredentials, "sp_user_select_by_credentials").FirstOrDefault();
        }
    }
}