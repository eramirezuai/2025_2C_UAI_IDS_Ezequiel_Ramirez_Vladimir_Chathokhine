using System.Linq;
using System.Collections.Generic;
using Framework.DAL;

namespace Framework.Services.Localization
{
    public enum LanguageParameterMappings
    {
        Create,
        Retrieve,
        Update,
        Delete
    }

    public class LanguageCrud : EntityCrud<Language, LanguageParameterMappings>
    {
        public LanguageCrud(IAccess access, IParameterMapper<Language, LanguageParameterMappings> parameterMapper) : base(access, parameterMapper, parameterMapper)
        {
        }

        public override void Create(Language data)
        {
            base.Create(data, LanguageParameterMappings.Create, "language_insert");
        }

        public override void Delete(Language data)
        {
            base.Delete(data, LanguageParameterMappings.Delete, "language_delete");
        }

        public override void Delete(Language data, Dictionary<string, object> args)
        {
            base.Delete(data, LanguageParameterMappings.Delete, "language_delete");
        }

        public override IEnumerable<Language> Retrieve()
        {
            return base.Retrieve(LanguageParameterMappings.Retrieve, "language_select_all");
        }

        public override IEnumerable<Language> Retrieve(Dictionary<string, object> args)
        {
            return base.Retrieve(LanguageParameterMappings.Retrieve, "language_select_all");
        }

        public override void Update(Language data)
        {
            base.Update(data, LanguageParameterMappings.Update, "language_update");
        }
    }
}