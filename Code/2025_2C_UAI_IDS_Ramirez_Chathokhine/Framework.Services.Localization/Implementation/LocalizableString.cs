using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services.Localization
{
    class LocalizableString : ILocalizableObject
    {
        private string stringId;
        private string innerString = "";

        public object LocalizationInstance => this;

        public string LocalizationKey => stringId;

        public LocalizableString(string stringId)
        {
            this.stringId = stringId;
        }

        public void Update(string text)
        {
            this.innerString = text;
        }

        public override string ToString()
        {
            return innerString;
        }
    }
}
