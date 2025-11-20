using Framework.DAL;
using System.Collections.Generic;

namespace Framework.Services.Security.Credentials
{
    public enum FamilyParameterMappings
    {
        Create,
        Retrieve,
        Update,
        Delete,
        RetrieveByUser,
        RetrieveByFamily
    }

    public class FamilyCrud : EntityCrud<Family, FamilyParameterMappings>
    {
        private PatentCrud patentCrud;

        public FamilyCrud(IAccess access, IParameterMapper<Family, FamilyParameterMappings> parameterMapper) : base(access, parameterMapper, parameterMapper)
        {

        }

        public override void Create(Family data)
        {
            base.Create(data, FamilyParameterMappings.Create, "family_insert");
        }

        public override void Delete(Family data)
        {
            base.Delete(data, FamilyParameterMappings.Delete, "family_delete");
        }

        public override void Delete(Family data, Dictionary<string, object> args)
        {
            base.Delete(data, FamilyParameterMappings.Delete, "family_delete");
        }

        public override IEnumerable<Family> Retrieve()
        {
            return base.Retrieve(FamilyParameterMappings.Retrieve, "family_select_all");
        }

        public override IEnumerable<Family> Retrieve(Dictionary<string, object> args)
        {
            return base.Retrieve(FamilyParameterMappings.Retrieve, "family_select_all");
        }

        public override void Update(Family data)
        {
            base.Update(data, FamilyParameterMappings.Update, "family_update");
        }

        public IEnumerable<Family> RetrieveByUser(User user)
        {
            var parameters = new Dictionary<string, object>()
            {
                {"@user_id",user.Id}//args del diccionario
            };
            return base.Retrieve(parameters, FamilyParameterMappings.RetrieveByUser, "USER_SELECT_FAMILIES");
        }

        public IEnumerable<Family> RetrieveByFamily(Family family)
        {
            var parameters = new Dictionary<string, object>()
            {
                {"@family_id",family.Id}//args del diccionario
            };
            return base.Retrieve(parameters, FamilyParameterMappings.RetrieveByFamily, "FAMILY_SELECT_FAMILIES");
        }

    }
}
