using System;
using System.Collections.Generic;

namespace Framework.Services.Localization
{
    public static class Localizer
    {
        private static LocalizationManager instance;

        public static void LocalizeControl(LocalizationManager manager, string id, Control control)
        {
            var controlType = control.GetType();
            new LocalizedControl<Control>(manager, id, control);
        }

        public static void LocalizeControl(string id, Control control)
        {
            LocalizeControl(Localizer.CurrentManager, id, control);
        }

        public static LocalizationManager InitLocalization(IEnumerable<LocalizationTable> tables)
        {
            if (instance == null)
            {
                instance = new LocalizationManager(tables);
            }
            return instance;
        }

        public static LocalizationManager SetLocalization(LocalizationTable[] tables)
        {
            if (instance != null)
            {
                var newManager = new LocalizationManager(tables, instance);
                instance = newManager;
            }
               
            return instance;
        }

        public static void LocalizeObject(LocalizationManager manager, object instance, Action<string> updater, string stringId)
        {
            manager.Attach(new LocalizableAction(instance, updater), stringId);
        }

        public static void LocalizeObject(object instance, Action<string> updater, string stringId)
        {
            LocalizeObject(CurrentManager, instance, updater, stringId);
        }

        public static LocalizationManager CurrentManager
        {
            get
            {
                return instance;
            }
        }        

        public static bool HasEntry(string stringId)
        {
            return CurrentManager.HasString(stringId);
        }

        public static void ApplyChanges()
        {
            instance.Notify();
        }

        public static void Dettach(LocalizationManager manager, ILocalizableObject obj)
        {
            manager.Dettach(obj);
        }

        public static void Dettach(ILocalizableObject obj)
        {
            Dettach(Localizer.CurrentManager, obj);
        }

        public static void Dettach(LocalizationManager manager, object obj)
        {
            manager.Dettach(obj);
        }

        public static void Dettach(object obj)
        {
            Dettach(Localizer.CurrentManager, obj);
        }
    }
}
