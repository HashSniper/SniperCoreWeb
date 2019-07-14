using Sniper.Core;
using Sniper.Core.Configuration;
using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Security;
using Sniper.Services.Plugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace Sniper.Services.Localization
{
    public interface ILocalizationService
    {
        /// <summary>
        /// 删除本地资源
        /// </summary>
        /// <param name="localeStringResource"></param>
        void DeleteLocaleStringResource(LocaleStringResource localeStringResource);

        /// <summary>
        /// 根据id获取本地资源
        /// </summary>
        /// <param name="localeStringResourceId"></param>
        /// <returns></returns>
        LocaleStringResource GetLocaleStringResourceById(int localeStringResourceId);

        /// <summary>
        /// 根据名称获取资源
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        LocaleStringResource GetLocaleStringResourceByName(string resourceName);

        /// <summary>
        /// 获取本地资源
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="languageId"></param>
        /// <param name="logIfNotFound"></param>
        /// <returns></returns>
        LocaleStringResource GetLocaleStringResourceByName(string resourceName, int languageId, bool logIfNotFound = true);

        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <param name="languageId"></param>
        /// <returns></returns>
        IList<LocaleStringResource> GetAllResources(int languageId);

        /// <summary>
        /// 插入资源
        /// </summary>
        /// <param name="localeStringResource"></param>
        void InsertLocaleStringResource(LocaleStringResource localeStringResource);

        /// <summary>
        /// 更新资源
        /// </summary>
        /// <param name="localeStringResource"></param>
        void UpdateLocaleStringResource(LocaleStringResource localeStringResource);

        /// <summary>
        /// 获取资源键值对
        /// </summary>
        /// <param name="languageId"></param>
        /// <param name="loadPublicLocales"></param>
        /// <returns></returns>
        Dictionary<string, KeyValuePair<int, string>> GetAllResourceValues(int languageId, bool? loadPublicLocales);

        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="resourceKey"></param>
        /// <returns></returns>
        string GetResource(string resourceKey);

        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="resourceKey"></param>
        /// <param name="languageId"></param>
        /// <param name="logIfNotFound"></param>
        /// <param name="defaultValue"></param>
        /// <param name="returnEmptyIfNotFound"></param>
        /// <returns></returns>
        string GetResource(string resourceKey, int languageId,bool logIfNotFound = true, string defaultValue = "", bool returnEmptyIfNotFound = false);

        /// <summary>
        /// 导出资源
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        string ExportResourcesToXml(Language language);

        /// <summary>
        /// 导入资源
        /// </summary>
        /// <param name="language"></param>
        /// <param name="xmlStreamReader"></param>
        /// <param name="updateExistingResources"></param>
        void ImportResourcesFromXml(Language language, StreamReader xmlStreamReader, bool updateExistingResources = true);

        /// <summary>
        /// 获取实体的本地化属性
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TPropType"></typeparam>
        /// <param name="entity"></param>
        /// <param name="keySelector"></param>
        /// <param name="languageId"></param>
        /// <param name="returnDefaultValue"></param>
        /// <param name="ensureTwoPublishedLanguages"></param>
        /// <returns></returns>
        TPropType GetLocalized<TEntity, TPropType>(TEntity entity, Expression<Func<TEntity, TPropType>> keySelector,
        int? languageId = null, bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true) where TEntity : BaseEntity, ILocalizedEntity;

        /// <summary>
        /// 获取实体的本地化属性
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="settings"></param>
        /// <param name="keySelector"></param>
        /// <param name="languageId"></param>
        /// <param name="storeId"></param>
        /// <param name="returnDefaultValue"></param>
        /// <param name="ensureTwoPublishedLanguages"></param>
        /// <returns></returns>
        string GetLocalizedSetting<TSettings>(TSettings settings, Expression<Func<TSettings, string>> keySelector,
        int languageId, int storeId, bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true)where TSettings : ISettings, new();

        /// <summary>
        /// 保存获取实体的本地化属性
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="settings"></param>
        /// <param name="keySelector"></param>
        /// <param name="languageId"></param>
        /// <param name="value"></param>
        void SaveLocalizedSetting<TSettings>(TSettings settings, Expression<Func<TSettings, string>> keySelector,
        int languageId, string value) where TSettings : ISettings, new();

        /// <summary>
        /// 获取本地资源枚举
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumValue"></param>
        /// <param name="languageId"></param>
        /// <returns></returns>
        string GetLocalizedEnum<TEnum>(TEnum enumValue, int? languageId = null) where TEnum : struct;

        /// <summary>
        /// 获取本地资源权限
        /// </summary>
        /// <param name="permissionRecord"></param>
        /// <param name="languageId"></param>
        /// <returns></returns>
        string GetLocalizedPermissionName(PermissionRecord permissionRecord, int? languageId = null);

        /// <summary>
        /// 保存本子资源权限
        /// </summary>
        /// <param name="permissionRecord"></param>
        void SaveLocalizedPermissionName(PermissionRecord permissionRecord);

        /// <summary>
        /// 删除本地资源权限
        /// </summary>
        /// <param name="permissionRecord"></param>
        void DeleteLocalizedPermissionName(PermissionRecord permissionRecord);

        /// <summary>
        /// 插入或者更新本地插件资源
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="resourceValue"></param>
        /// <param name="languageCulture"></param>
        void AddOrUpdatePluginLocaleResource(string resourceName, string resourceValue, string languageCulture = null);

        /// <summary>
        /// 删除本地插件资源
        /// </summary>
        /// <param name="resourceName"></param>
        void DeletePluginLocaleResource(string resourceName);

        /// <summary>
        /// 获取本地资源
        /// </summary>
        /// <typeparam name="TPlugin"></typeparam>
        /// <param name="plugin"></param>
        /// <param name="languageId"></param>
        /// <param name="returnDefaultValue"></param>
        /// <returns></returns>
        string GetLocalizedFriendlyName<TPlugin>(TPlugin plugin, int languageId, bool returnDefaultValue = true) where TPlugin : IPlugin;

        /// <summary>
        /// 保存本地资源
        /// </summary>
        /// <typeparam name="TPlugin"></typeparam>
        /// <param name="plugin"></param>
        /// <param name="languageId"></param>
        /// <param name="localizedFriendlyName"></param>
        void SaveLocalizedFriendlyName<TPlugin>(TPlugin plugin, int languageId, string localizedFriendlyName)where TPlugin : IPlugin;
    }
}
