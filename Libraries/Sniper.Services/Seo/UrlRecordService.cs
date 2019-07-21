using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Seo;
using Sniper.Data.EntityExtensions;
using Sniper.Services.Localization;
using System.Linq;

namespace Sniper.Services.Seo
{
    public partial class UrlRecordService : IUrlRecordService
    {
        #region Fields

        private static readonly object _lock = new object();
        private static Dictionary<string, string> _seoCharacterTable;

        private readonly ILanguageService _languageService;
        private readonly IRepository<UrlRecord> _urlRecordRepository;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IWorkContext _workContext;
        private readonly LocalizationSettings _localizationSettings;
        private readonly SeoSettings _seoSettings;

        #endregion

        #region Ctor

        public UrlRecordService(ILanguageService languageService,
            IRepository<UrlRecord> urlRecordRepository,
            IStaticCacheManager cacheManager,
            IWorkContext workContext,
            LocalizationSettings localizationSettings,
            SeoSettings seoSettings)
        {
            _languageService = languageService;
            _urlRecordRepository = urlRecordRepository;
            _cacheManager = cacheManager;
            _workContext = workContext;
            _localizationSettings = localizationSettings;
            _seoSettings = seoSettings;
        }

        #endregion

        #region Methods
        public void DeleteUrlRecord(UrlRecord urlRecord)
        {
            throw new NotImplementedException();
        }

        public void DeleteUrlRecords(IList<UrlRecord> urlRecords)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// slug
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="entityName"></param>
        /// <param name="languageId"></param>
        /// <returns></returns>
        public string GetActiveSlug(int entityId, string entityName, int languageId)
        {
            if (_localizationSettings.LoadAllUrlRecordsOnStartup)
            {
                var key = string.Format(NopSeoDefaults.UrlRecordActiveByIdNameLanguageCacheKey, entityId, entityName, languageId);
                return _cacheManager.Get(key, () =>
                 {
                     var source = GetAllUrlRecordsCached();
                     var query = from ur in source
                                 where ur.EntityId == entityId && ur.EntityName == entityName && ur.LanguageId == languageId && ur.IsActive
                                 orderby ur.Id descending
                                 select ur.Slug;

                     var slug = query.FirstOrDefault() ?? string.Empty;

                     return slug;
                 });
            }
            else
            {
                var key = string.Format(NopSeoDefaults.UrlRecordActiveByIdNameLanguageCacheKey, entityId, entityName, languageId);
                return _cacheManager.Get(key, () =>
                 {
                     var source = _urlRecordRepository.Table;

                     var query = from ur in source
                                 where ur.EntityId == entityId && ur.EntityName == entityName && ur.LanguageId == languageId && ur.IsActive
                                 orderby ur.Id descending
                                 select ur.Slug;

                     var slug = query.FirstOrDefault() ?? string.Empty;

                     return slug;
                 });
            }
        }

        public IPagedList<UrlRecord> GetAllUrlRecords(string slug = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public UrlRecord GetBySlug(string slug)
        {
            throw new NotImplementedException();
        }

        public UrlRecordForCaching GetBySlugCached(string slug)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取搜索引擎友好名称（slug）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="languageId"></param>
        /// <param name="returnDefaultValue"></param>
        /// <param name="ensureTwoPublishedLanguages"></param>
        /// <returns></returns>
        public string GetSeName<T>(T entity, int? languageId = null, bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true) where T : BaseEntity, ISlugSupported
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityName = entity.GetUnproxiedEntityType().Name;
            return GetSeName(entity.Id, entityName, languageId ?? _workContext.WorkingLanguage.Id, returnDefaultValue, ensureTwoPublishedLanguages);
        }

        public string GetSeName(int entityId, string entityName, int? languageId = null, bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true)
        {
            languageId = languageId ?? _workContext.WorkingLanguage.Id;

            var result = string.Empty;

            languageId = languageId ?? _workContext.WorkingLanguage.Id;

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
                    result = GetActiveSlug(entityId, entityName, languageId.Value);
                }

            }

            if (string.IsNullOrEmpty(result) && returnDefaultValue)
            {
                result = GetActiveSlug(entityId, entityName, 0);
            }

            return result;
        }

        public string GetSeName(string name, bool convertNonWesternChars, bool allowUnicodeCharsInUrls)
        {
            throw new NotImplementedException();
        }

        public UrlRecord GetUrlRecordById(int urlRecordId)
        {
            throw new NotImplementedException();
        }

        public void InsertUrlRecord(UrlRecord urlRecord)
        {
            throw new NotImplementedException();
        }

        public void SaveSlug<T>(T entity, string slug, int languageId) where T : BaseEntity, ISlugSupported
        {
            throw new NotImplementedException();
        }

        public void UpdateUrlRecord(UrlRecord urlRecord)
        {
            throw new NotImplementedException();
        }

        public string ValidateSeName<T>(T entity, string seName, string name, bool ensureNotEmpty) where T : BaseEntity, ISlugSupported
        {
            throw new NotImplementedException();
        }

        public string ValidateSeName(int entityId, string entityName, string seName, string name, bool ensureNotEmpty)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Nested classes

        /// <summary>
        /// UrlRecord (for caching)
        /// </summary>
        [Serializable]
        public class UrlRecordForCaching
        {
            public int Id { get; set; }

            public int EntityId { get; set; }

            public string EntityName { get; set; }

            public string Slug { get; set; }

            public bool IsActive { get; set; }

            public int LanguageId { get; set; }
        }

        #endregion

        #region Utilities
        /// <summary>
        /// 获取所有缓存的URL记录
        /// </summary>
        /// <returns></returns>
        protected virtual IList<UrlRecordForCaching> GetAllUrlRecordsCached()
        {
            return _cacheManager.Get(NopSeoDefaults.UrlRecordAllCacheKey, () =>
             {
                 var query = from ur in _urlRecordRepository.TableNoTracking
                             select ur;

                 var urlRecords = query.ToList();

                 var list = new List<UrlRecordForCaching>();

                 foreach (var ur in urlRecords)
                 {
                     var urlRecordForCaching = Map(ur);
                     list.Add(urlRecordForCaching);
                 }

                 return list;
             });
        }

        /// <summary>
        /// Map
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        protected UrlRecordForCaching Map(UrlRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var urlRecordForCaching = new UrlRecordForCaching
            {
                Id = record.Id,
                EntityId = record.EntityId,
                EntityName = record.EntityName,
                Slug = record.Slug,
                IsActive = record.IsActive,
                LanguageId = record.LanguageId
            };
            return urlRecordForCaching;
        }
        #endregion
    }
}
