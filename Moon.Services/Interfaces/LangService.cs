using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;

namespace Moon.Services.Services
{
    public class LangService(ResourceManager resourceManager) : ILangService
    {
        private readonly ResourceManager _resourceManager = resourceManager;

        public event EventHandler<CultureInfo>? LanguageChanged;
        public CultureInfo CurrentCulture { get; private set; } = CultureInfo.CurrentUICulture;

        public string this[string key] =>
            _resourceManager.GetString(key, CurrentCulture) ?? key;

        public void SetCulture(string cultureName)
        {
            var culture = new CultureInfo(cultureName);
            CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            LanguageChanged?.Invoke(this, culture);
        }
    }
}
