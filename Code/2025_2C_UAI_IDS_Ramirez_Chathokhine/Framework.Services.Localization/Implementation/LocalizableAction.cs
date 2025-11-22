using System;

namespace Framework.Services.Localization
{
    internal class LocalizableAction : ILocalizableObject
    {
        private string stringId;
        private object instance;
        private Action<string> updater;

        public object LocalizationInstance => instance;

        public string LocalizationKey => stringId;

        public LocalizableAction(object instance, Action<string> localizer)
        {
            this.instance = instance;
            this.updater = localizer;
        }

        public void Update(string text)
        {
            updater(text);
        }
    }
}
