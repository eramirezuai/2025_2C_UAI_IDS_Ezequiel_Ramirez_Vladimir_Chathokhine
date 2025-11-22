using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services.Localization
{
    public interface ILocalizableObject
    {
        void Update(string text);
        object LocalizationInstance { get; }
        string LocalizationKey { get; }
    }
}
