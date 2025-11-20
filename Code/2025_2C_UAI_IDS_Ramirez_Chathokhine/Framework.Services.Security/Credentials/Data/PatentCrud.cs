using Framework.DAL;
using System.Collections.Generic;

namespace Framework.Services.Security.Credentials
{
    public enum PatentParameterMappings
    {
        Create,
        Retrieve,
        RetrieveByParent,
        Update,
        Delete
    }

    public class PatentCrud : EntityCrud<Patent, PatentParameterMappings>
    {
        public PatentCrud(IAccess access, IParameterMapper<Patent, PatentParameterMappings> parameterMapper) : base(access, parameterMapper, parameterMapper)
        {
        }

        public override void Create(Patent data)
        {
            base.Create(data, PatentParameterMappings.Create, "patent_insert");
        }

        public override void Delete(Patent data)
        {
            base.Delete(data, PatentParameterMappings.Delete, "patent_delete");
        }

        public override void Delete(Patent data, Dictionary<string, object> args)
        {
            base.Delete(data, PatentParameterMappings.Delete, "patent_delete");
        }

        public override IEnumerable<Patent> Retrieve()
        {
            return base.Retrieve(PatentParameterMappings.Retrieve, "patent_select_all");
        }

        public override IEnumerable<Patent> Retrieve(Dictionary<string, object> args)
        {
            return base.Retrieve(PatentParameterMappings.Retrieve, "patent_select_all");
        }

        public override void Update(Patent data)
        {
            base.Update(data, PatentParameterMappings.Update, "patent_update");
        }

        public IEnumerable<Patent> RetrieveByParent(Family parent)
        {
            var parameters = new Dictionary<string, object>()
            {
                {"@family_id",parent.Id}
            };
            return base.Retrieve(parameters,PatentParameterMappings.RetrieveByParent, "family_select_patents");
        }
    }
}
