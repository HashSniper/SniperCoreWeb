using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using Sniper.Core;
using Sniper.Core.Configuration;
using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Security;
using Sniper.Services.Plugins;

namespace Sniper.Services.Localization
{
    public partial class LocalizationService : ILocalizationService
    {
        public void AddOrUpdatePluginLocaleResource(string resourceName, string resourceValue, string languageCulture = null)
        {
            throw new NotImplementedException();
        }

        public void DeleteLocaleStringResource(LocaleStringResource localeStringResource)
        {
            throw new NotImplementedException();
        }

        public void DeleteLocalizedPermissionName(PermissionRecord permissionRecord)
        {
            throw new NotImplementedException();
        }

        public void DeletePluginLocaleResource(string resourceName)
        {
            throw new NotImplementedException();
        }

        public string ExportResourcesToXml(Language language)
        {
            throw new NotImplementedException();
        }

        public IList<LocaleStringResource> GetAllResources(int languageId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, KeyValuePair<int, string>> GetAllResourceValues(int languageId, bool? loadPublicLocales)
        {
            throw new NotImplementedException();
        }

        public LocaleStringResource GetLocaleStringResourceById(int localeStringResourceId)
        {
            throw new NotImplementedException();
        }

        public LocaleStringResource GetLocaleStringResourceByName(string resourceName)
        {
            throw new NotImplementedException();
        }

        public LocaleStringResource GetLocaleStringResourceByName(string resourceName, int languageId, bool logIfNotFound = true)
        {
            throw new NotImplementedException();
        }

        public TPropType GetLocalized<TEntity, TPropType>(TEntity entity, Expression<Func<TEntity, TPropType>> keySelector, int? languageId = null, bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true) where TEntity : BaseEntity, ILocalizedEntity
        {
            throw new NotImplementedException();
        }

        public string GetLocalizedEnum<TEnum>(TEnum enumValue, int? languageId = null) where TEnum : struct
        {
            throw new NotImplementedException();
        }

        public string GetLocalizedFriendlyName<TPlugin>(TPlugin plugin, int languageId, bool returnDefaultValue = true) where TPlugin : IPlugin
        {
            throw new NotImplementedException();
        }

        public string GetLocalizedPermissionName(PermissionRecord permissionRecord, int? languageId = null)
        {
            throw new NotImplementedException();
        }

        public string GetLocalizedSetting<TSettings>(TSettings settings, Expression<Func<TSettings, string>> keySelector, int languageId, int storeId, bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true) where TSettings : ISettings, new()
        {
            throw new NotImplementedException();
        }

        public string GetResource(string resourceKey)
        {
            throw new NotImplementedException();
        }

        public string GetResource(string resourceKey, int languageId, bool logIfNotFound = true, string defaultValue = "", bool returnEmptyIfNotFound = false)
        {
            throw new NotImplementedException();
        }

        public void ImportResourcesFromXml(Language language, StreamReader xmlStreamReader, bool updateExistingResources = true)
        {
            throw new NotImplementedException();
        }

        public void InsertLocaleStringResource(LocaleStringResource localeStringResource)
        {
            throw new NotImplementedException();
        }

        public void SaveLocalizedFriendlyName<TPlugin>(TPlugin plugin, int languageId, string localizedFriendlyName) where TPlugin : IPlugin
        {
            throw new NotImplementedException();
        }

        public void SaveLocalizedPermissionName(PermissionRecord permissionRecord)
        {
            throw new NotImplementedException();
        }

        public void SaveLocalizedSetting<TSettings>(TSettings settings, Expression<Func<TSettings, string>> keySelector, int languageId, string value) where TSettings : ISettings, new()
        {
            throw new NotImplementedException();
        }

        public void UpdateLocaleStringResource(LocaleStringResource localeStringResource)
        {
            throw new NotImplementedException();
        }
    }
}
