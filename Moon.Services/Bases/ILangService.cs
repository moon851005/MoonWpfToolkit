using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Moon.Services.Services
{
    public interface ILangService
    {
        string this[string key] { get; }
        CultureInfo CurrentCulture { get; }
        void SetCulture(string cultureName);
        event EventHandler<CultureInfo>? LanguageChanged;
    }
}
