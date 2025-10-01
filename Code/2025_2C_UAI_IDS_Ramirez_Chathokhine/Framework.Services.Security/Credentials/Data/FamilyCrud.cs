using Framework.DAL;
using System.Collections.Generic;

namespace Framework.Services.Security.Credentials
{
    public enum FamilyParameterMappings
    {
        Create,
        Retrieve,
        Update,
        Delete
    }

    public class FamilyCrud : EntityCrud<Family, FamilyParameterMappings>
    {
        private PatentCrud patentCrud;

        public FamilyCrud(IAccess access, IParameterMapper<Family, FamilyParameterMappings> parameterMapper, PatentCrud patentCrud) : base(access, parameterMapper, parameterMapper)
        {
            this.patentCrud = patentCrud;
        }

        public override void Create(Family data)
        {
            base.Create(data, FamilyParameterMappings.Create, "sp_family_insert");
        }

        public override void Delete(Family data)
        {
            base.Delete(data, FamilyParameterMappings.Delete, "sp_family_delete");
        }

        public override void Delete(Family data, Dictionary<string, object> args)
        {
            base.Delete(data, FamilyParameterMappings.Delete, "sp_family_delete");
        }

        public override IEnumerable<Family> Retrieve()
        {
            return base.Retrieve(FamilyParameterMappings.Retrieve, "sp_family_select_all");
        }

        public override IEnumerable<Family> Retrieve(Dictionary<string, object> args)
        {
            return base.Retrieve(FamilyParameterMappings.Retrieve, "sp_family_select_all");
        }

        public override void Update(Family data)
        {
            base.Update(data, FamilyParameterMappings.Update, "sp_family_update");
        }
    }
}
