using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Configuration;
using Sniper.Core.Data;
using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Security;
using Sniper.Data;
using Sniper.Data.EntityExtensions;
using Sniper.Services.Configuration;
using Sniper.Services.Events;
using Sniper.Services.Logging;
using Sniper.Services.Plugins;

namespace Sniper.Services.Localization
{
    public partial class LocalizationService : ILocalizationService
    {
        #region Fields

        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILanguageService _languageService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly ILogger _logger;
        private readonly IRepository<LocaleStringResource> _lsrRepository;
        private readonly ISettingService _settingService;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IWorkContext _workContext;
        private readonly LocalizationSettings _localizationSettings;

        #endregion

        #region Ctor

        public LocalizationService(IDataProvider dataProvider,
            IDbContext dbContext,
            IEventPublisher eventPublisher,
            ILanguageService languageService,
            ILocalizedEntityService localizedEntityService,
            ILogger logger,
            IRepository<LocaleStringResource> lsrRepository,
            ISettingService settingService,
            IStaticCacheManager cacheManager,
            IWorkContext workContext,
            LocalizationSettings localizationSettings)
        {
            _dataProvider = dataProvider;
            _dbContext = dbContext;
            _eventPublisher = eventPublisher;
            _languageService = languageService;
            _localizedEntityService = localizedEntityService;
            _logger = logger;
            _lsrRepository = lsrRepository;
            _settingService = settingService;
            _cacheManager = cacheManager;
            _workContext = workContext;
            _localizationSettings = localizationSettings;
        }

        #endregion

        #region Methods
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
        public TPropType GetLocalized<TEntity, TPropType>(TEntity entity, Expression<Func<TEntity, TPropType>> keySelector, int? languageId = null, bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true) where TEntity : BaseEntity, ILocalizedEntity
        {
            if(entity==null)
                throw new ArgumentNullException(nameof(entity));

            if (!(keySelector.Body is MemberExpression member))
                throw new ArgumentException($"Expression '{keySelector}' refers to a method, not a property.");

            if (!(member.Member is PropertyInfo propInfo))
                throw new ArgumentException($"Expression '{keySelector}' refers to a field, not a property.");

            var result = default(TPropType);

            var resultStr = string.Empty;

            var localeKeyGroup = entity.GetUnproxiedEntityType().Name;

            var localeKey = propInfo.Name;
            if (!languageId.HasValue)
                languageId = _workContext.WorkingLanguage.Id;

            if (languageId > 0)
            {
                var loadLocalizedValue = true;

                if (ensureTwoPublishedLanguages)
                {
                    var totalPublishedLanguages = _languageService.GetAllLanguages().Count;
                    loadLocalizedValue = totalPublishedLanguages >= 2;
                }

                if (loadLocalizedValue)
                {
                    resultStr = _localizedEntityService.GetLocalizedValue(languageId.Value, entity.Id, localeKeyGroup, localeKey);

                    if (!string.IsNullOrEmpty(resultStr))
                    {
                        result = CommonHelper.To<TPropType>(resultStr);
                    }
                }
            }

            if (!string.IsNullOrEmpty(resultStr) || !returnDefaultValue)
                return result;

            var localizer = keySelector.Compile();

            result = localizer(entity);

            return result;

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
        #endregion
    }
}
