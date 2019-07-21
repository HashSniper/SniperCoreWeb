using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Localization;

namespace Sniper.Services.Localization
{
    public partial class LocalizedEntityService : ILocalizedEntityService
    {
        #region Fields

        private readonly IRepository<LocalizedProperty> _localizedPropertyRepository;
        private readonly IStaticCacheManager _cacheManager;
        private readonly LocalizationSettings _localizationSettings;

        #endregion

        #region Ctor

        public LocalizedEntityService(IRepository<LocalizedProperty> localizedPropertyRepository,
            IStaticCacheManager cacheManager,
            LocalizationSettings localizationSettings)
        {
            _localizedPropertyRepository = localizedPropertyRepository;
            _cacheManager = cacheManager;
            _localizationSettings = localizationSettings;
        }

        #endregion

        #region Methods
        public void DeleteLocalizedProperty(LocalizedProperty localizedProperty)
        {
            throw new NotImplementedException();
        }

        public LocalizedProperty GetLocalizedPropertyById(int localizedPropertyId)
        {
            throw new NotImplementedException();
        }

        public string GetLocalizedValue(int languageId, int entityId, string localeKeyGroup, string localeKey)
        {
            throw new NotImplementedException();
        }

        public void InsertLocalizedProperty(LocalizedProperty localizedProperty)
        {
            throw new NotImplementedException();
        }

        public void SaveLocalizedValue<T>(T entity, Expression<Func<T, string>> keySelector, string localeValue, int languageId) where T : BaseEntity, ILocalizedEntity
        {
            throw new NotImplementedException();
        }

        public void SaveLocalizedValue<T, TPropType>(T entity, Expression<Func<T, TPropType>> keySelector, TPropType localeValue, int languageId) where T : BaseEntity, ILocalizedEntity
        {
            throw new NotImplementedException();
        }

        public void UpdateLocalizedProperty(LocalizedProperty localizedProperty)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
