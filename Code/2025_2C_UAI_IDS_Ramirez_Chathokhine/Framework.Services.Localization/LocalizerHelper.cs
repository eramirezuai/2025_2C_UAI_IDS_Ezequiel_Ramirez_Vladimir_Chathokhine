using Framework.Services.Localization.Editor.Containers;
using Framework.Services.Localization.Game.Containers;
using System;
using System.Collections.Generic;

namespace Framework.Services.Localization
{
    public static class LocalizerHelper
    {
        public const int EDITOR = 0;
        public const int GAME = 1;

        public static void ConnectToDatabase(string connString)
        {
            DBAccess.Instance.Connect(connString);
        }

        public static void CreateGameLocalizer(bool reloadTables = true)
        {
            CreateGameLocalizer(string.Empty, reloadTables);
        }

        public static void CreateGameLocalizer(string connString, bool reloadTables)
        {
            if (!string.IsNullOrEmpty(connString) && !DBAccess.Instance.IsConnected())
            {
                ConnectToDatabase(connString);
            }

            if (reloadTables)
            {
                GameLanguageContainer.Instance.PersistLoad();
                GameStringContainer.Instance.PersistLoad();
                LocalizedGameStringContainer.Instance.PersistLoad();
            }
            var tables = new List<LocalizationTable>();

            foreach (var lang in GameLanguageContainer.Instance.Items)
            {
                var table = new LocalizationTable(lang.Name, lang.Name);
                foreach (var str in LocalizedGameStringContainer.Instance.FromLanguage(lang))
                {
                    table.AddEntry(str.String.Name, str.Data);
                }
                tables.Add(table);
            }
            if (Localizer.CurrentManager == null)
                Localizer.InitLocalization(tables.ToArray());
            else
                Localizer.SetLocalization(tables.ToArray());
        }

        public static void CreateLocalizer(bool reloadTables = true)
        {
            CreateLocalizer(string.Empty, reloadTables);
        }

        public static void CreateLocalizer(string connString, bool reloadTables)
        {
            if (!string.IsNullOrEmpty(connString) && !DBAccess.Instance.IsConnected())
            {
                ConnectToDatabase(connString);
            }
        
            if(reloadTables)
            {
                SystemLanguageContainer.Instance.PersistLoad();
                SystemLanguageCodeContainer.Instance.PersistLoad();
                SystemLanguageStringContainer.Instance.PersistLoad();
            }
            var tables = new List<LocalizationTable>();

            foreach(var lang in SystemLanguageContainer.Instance.Items)
            {
                var table = new LocalizationTable(lang.Name, lang.Code);
                foreach(var str in SystemLanguageStringContainer.Instance.FromLanguage(lang))
                {
                    table.AddEntry(str.Code, str.Data);
                }
                tables.Add(table);  
            }
            if(Localizer.CurrentManager == null)
                Localizer.InitLocalization(tables.ToArray());
            else
                Localizer.SetLocalization(tables.ToArray());
        }

        public static void SoftResetLocalizer(int type = EDITOR)
        {
            if (type == EDITOR)
                SoftResetEditorLocalizer();
            else if (type == GAME)
                SoftResetGameLocalizer();
            else
                throw new ArgumentException();
        }

        private static void SoftResetGameLocalizer()
        {
            var lang = Localizer.CurrentManager.CurrentLanguage;
            CreateGameLocalizer(false);
            Localizer.CurrentManager.CurrentLanguage = lang;
            Localizer.ApplyChanges();
        }

        private static void SoftResetEditorLocalizer()
        {
            var lang = Localizer.CurrentManager.CurrentLanguage;
            CreateLocalizer(false);
            Localizer.CurrentManager.CurrentLanguage = lang;
            Localizer.ApplyChanges();
        }

        public static void HardResetLocalizer(int type = EDITOR)
        {
            if (type == EDITOR)
                HardResetEditorLocalizer();
            else if (type == GAME)
                HardResetGameLocalizer();
            else
                throw new ArgumentException();
        }

        private static void HardResetGameLocalizer()
        {
            var lang = Localizer.CurrentManager.CurrentLanguage;
            CreateGameLocalizer(true);
            Localizer.CurrentManager.CurrentLanguage = lang;
            Localizer.ApplyChanges();
        }

        private static void HardResetEditorLocalizer()
        {
            var lang = Localizer.CurrentManager.CurrentLanguage;
            CreateLocalizer(true);
            Localizer.CurrentManager.CurrentLanguage = lang;
            Localizer.ApplyChanges();
        }
    }
}
