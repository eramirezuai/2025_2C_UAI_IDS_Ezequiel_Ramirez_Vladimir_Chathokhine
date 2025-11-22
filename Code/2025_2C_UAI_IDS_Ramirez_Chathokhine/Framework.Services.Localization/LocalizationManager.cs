using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalizationTable = System.Collections.Generic.Dictionary<string, string>;

namespace Framework.Services.Localization
{
    struct LocalizableRelation
    {
        public ILocalizableObject Object;
        public string Id;

        public LocalizableRelation(ILocalizableObject obj, string id)
        {
            this.Object = obj;
            this.Id = id;
        }

        public override bool Equals(object obj)
        {
            if(obj is LocalizableRelation)
            {
                return ((LocalizableRelation)obj).Object == this.Object;
            }
            return base.Equals(obj);
        }
    }

    public class LocalizationManager 
    {
        private string currentLanguage;
        private Dictionary<string, LocalizationTable> tables = new Dictionary<string, LocalizationTable>();
        private List<ILocalizableObject> objects = new List<ILocalizableObject>();

        public LocalizationManager(IEnumerable<LocalizationTable> tables)
        {
            foreach(var table in tables)
            {
                this.tables.Add(table.LanguageCode, table);
            }
        }
    
        public string CurrentLanguage
        {
            get
            {
                return currentLanguage;
            }

            set
            {
                currentLanguage = value;
            }
        }

        public void Attach(ILocalizableObject obj)
        {
            objects.Add(obj);
        }

        public void Dettach(ILocalizableObject obj)
        {
            objects.Remove(obj);
        }

        public bool HasString(string stringId)
        {
            return tables[currentLanguage].ContainsEntry(stringId);
        }

        public string GetString(string stringId)
        {
            return tables[currentLanguage][stringId];
        }

        public void Notify()
        {
            foreach(var relation in objects)
            {
                relation.Update(tables[currentLanguage][relation.LocalizationKey]);
            }
        }
    }
}
