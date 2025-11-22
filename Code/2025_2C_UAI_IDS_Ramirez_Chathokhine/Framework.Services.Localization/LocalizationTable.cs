using System;
using System.Collections.Generic;

namespace Framework.Services.Localization
{
    public class LocalizationTable
    {
        private Dictionary<string, string> entries;
        private string languageName;
        private string languageCode;

        public LocalizationTable(string name, string code) : this(name, code, new Dictionary<string, string>())
        {
        }

        public LocalizationTable(string name, string code, Dictionary<string, string> entries)
        {
            this.languageName = name;
            this.languageCode = code;
            this.entries = entries;
        } 

        public string LanguageName
        {
            get
            {
                return languageName;
            }
        }

        public string LanguageCode
        {
            get
            {
                return languageCode;
            }
        }

        public string this[string code]
        {
            get
            {
                return entries[code];
            }
        }

        public void AddEntry(string code, string data)
        {
            entries.Add(code, data);
        }

        public void ModifyEntry(string code, string newData)
        {
            if(entries.ContainsKey(code))
            {
                entries[code] = newData;
            }
        }

        public void RemoveEntry(string code)
        {
            entries.Remove(code);
        }

        public bool ContainsEntry(string stringId)
        {
            return entries.ContainsKey(stringId);
        }
    }
}