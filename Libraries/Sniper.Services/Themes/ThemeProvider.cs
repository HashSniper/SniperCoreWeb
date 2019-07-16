using Newtonsoft.Json;
using Sniper.Core.Infrastructure;
using Sniper.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sniper.Services.Themes
{
    public partial class ThemeProvider : IThemeProvider
    {

        #region Fields
        private readonly INopFileProvider _fileProvider;
        private IList<ThemeDescriptor> _themeDescriptors;

        #endregion

        #region Ctor
        public ThemeProvider(INopFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        #endregion

        #region Methods
        public ThemeDescriptor GetThemeBySystemName(string systemName)
        {
            throw new NotImplementedException();
        }

        public ThemeDescriptor GetThemeDescriptorFromText(string text)
        {
            var themeDescriptor = JsonConvert.DeserializeObject<ThemeDescriptor>(text);

            if (_themeDescriptors?.Any(descriptor => descriptor.SystemName.Equals(themeDescriptor?.SystemName, StringComparison.InvariantCultureIgnoreCase)) ?? false)
            {
                throw new Exception($"A theme with '{themeDescriptor.SystemName}' system name is already defined");
            }
            return themeDescriptor;
        }

        public IList<ThemeDescriptor> GetThemes()
        {
            if (_themeDescriptors != null)
                return _themeDescriptors;

            _themeDescriptors = new List<ThemeDescriptor>();

            var themeDirectoryPath = _fileProvider.MapPath(SniperPluginDefaults.ThemesPath);

            foreach (var descriptionFile in _fileProvider.GetFiles(themeDirectoryPath, SniperPluginDefaults.ThemeDescriptionFileName, false))
            {
                var text = _fileProvider.ReadAllText(descriptionFile, Encoding.UTF8);
                if (string.IsNullOrEmpty(text))
                {
                    continue;
                }

                var themeDescriptor = GetThemeDescriptorFromText(text);

                if (string.IsNullOrEmpty(themeDescriptor?.SystemName))
                    throw new Exception($"A theme descriptor '{descriptionFile}' has no system name");

                _themeDescriptors.Add(themeDescriptor);
            }

            return _themeDescriptors;
        }

        public bool ThemeExists(string systemName)
        {
            if (string.IsNullOrEmpty(systemName))
                return false;

            return GetThemes().Any(p => p.SystemName.Equals(systemName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion
    }
}
