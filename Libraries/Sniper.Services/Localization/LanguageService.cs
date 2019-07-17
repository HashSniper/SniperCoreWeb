using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Localization;
using Sniper.Services.Configuration;
using Sniper.Services.Events;
using Sniper.Services.Stores;

namespace Sniper.Services.Localization
{
    public partial class LanguageService : ILanguageService
    {
        #region Fields
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<Language> _languageRepository;
        private readonly ISettingService _settingService;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IStoreMappingService _storeMappingService;
        private readonly LocalizationSettings _localizationSettings;
        #endregion

        #region Ctor
        public LanguageService(IEventPublisher eventPublisher,
            IRepository<Language> languageRepository,
            ISettingService settingService,
            IStaticCacheManager cacheManager,
            IStoreMappingService storeMappingService,
            LocalizationSettings localizationSettings)
        {
            _eventPublisher = eventPublisher;
            _languageRepository = languageRepository;
            _settingService = settingService;
            _cacheManager = cacheManager;
            _storeMappingService = storeMappingService;
            _localizationSettings = localizationSettings;
        }
        #endregion

        #region Methods
        public void DeleteLanguage(Language language)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有语言
        /// </summary>
        /// <param name="showHidden"></param>
        /// <param name="storeId"></param>
        /// <param name="loadCacheableCopy"></param>
        /// <returns></returns>
        public virtual IList<Language> GetAllLanguages(bool showHidden = false, int storeId = 0, bool loadCacheableCopy = true)
        {
            IList<Language> LoadLanguagesFunc()
            {
                var quey = _languageRepository.Table;
                if (!showHidden) quey = quey.Where(l => l.Published);
                quey = quey.OrderBy(l => l.DisplayOrder).ThenBy(l => l.Id);
                return quey.ToList();
            }

            IList<Language> languages;
            if (loadCacheableCopy)
            {
                var key = string.Format(NopLocalizationDefaults.LanguagesAllCacheKey, showHidden);
                languages = _cacheManager.Get(key, () =>
                   {
                       var result = new List<Language>();
                       foreach (var language in LoadLanguagesFunc())
                       {
                           result.Add(new LanguageForCaching(language));

                       }
                       return result;
                   });
            }
            else
            {
                languages = LoadLanguagesFunc();

            }

            //store mapping
            if (storeId > 0)
            {
                languages = languages
                    .Where(l => _storeMappingService.Authorize(l, storeId))
                    .ToList();
            }

            return languages;
        }

        public Language GetLanguageById(int languageId, bool loadCacheableCopy = true)
        {
            throw new NotImplementedException();
        }

        public string GetTwoLetterIsoLanguageName(Language language)
        {
            throw new NotImplementedException();
        }

        public void InsertLanguage(Language language)
        {
            throw new NotImplementedException();
        }

        public void UpdateLanguage(Language language)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
