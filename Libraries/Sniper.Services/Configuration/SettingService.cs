using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using Sniper.Core.Caching;
using Sniper.Core.Configuration;
using Sniper.Core.Data;
using Sniper.Core.Domain.Configuration;
using Sniper.Services.Events;
using System.Linq;
using Sniper.Core;

namespace Sniper.Services.Configuration
{
    public partial class SettingService : ISettingService
    {

        #region Fileds
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<Setting> _settingRepository;
        private readonly IStaticCacheManager _cacheManager;
        #endregion

        #region Ctor
        public SettingService(IEventPublisher eventPublisher, IRepository<Setting> settingRepository, IStaticCacheManager manager)
        {
            _eventPublisher = eventPublisher;
            _settingRepository = settingRepository;
            _cacheManager = manager;
        }
        #endregion

        #region Methods
        public void ClearCache()
        {
            throw new NotImplementedException();
        }

        public void DeleteSetting(Setting setting)
        {
            throw new NotImplementedException();
        }

        public void DeleteSetting<T>() where T : ISettings, new()
        {
            throw new NotImplementedException();
        }

        public void DeleteSetting<T, TPropType>(T settings, Expression<Func<T, TPropType>> keySelector, int storeId = 0) where T : ISettings, new()
        {
            throw new NotImplementedException();
        }

        public void DeleteSettings(IList<Setting> settings)
        {
            throw new NotImplementedException();
        }

        public IList<Setting> GetAllSettings()
        {
            throw new NotImplementedException();
        }

        public Setting GetSetting(string key, int storeId = 0, bool loadSharedValueIfNotFound = false)
        {
            throw new NotImplementedException();
        }

        public Setting GetSettingById(int settingId)
        {
            throw new NotImplementedException();
        }

        public virtual T GetSettingByKey<T>(string key, T defaultValue = default, int storeId = 0, bool loadSharedValueIfNotFound = false)
        {
            if (string.IsNullOrEmpty(key))
                return defaultValue;

            var settings = GetAllSettingsCached();
            key = key.Trim().ToLowerInvariant();
            if (!settings.ContainsKey(key))
                return defaultValue;

            var settingsByKey = settings[key];
            var setting = settingsByKey.FirstOrDefault(x => x.StoreId == storeId);

            if (setting == null && storeId > 0 && loadSharedValueIfNotFound)
                setting = settingsByKey.FirstOrDefault(x => x.StoreId == 0);

            return setting != null ? CommonHelper.To<T>(setting.Value) : defaultValue;
        }

        public string GetSettingKey<TSettings, T>(TSettings settings, Expression<Func<TSettings, T>> keySelector) where TSettings : ISettings, new()
        {
            throw new NotImplementedException();
        }

        public T LoadSetting<T>(int storeId = 0) where T : ISettings, new()
        {
            return (T)LoadSetting(typeof(T), storeId);
        }

        public ISettings LoadSetting(Type type, int storeId = 0)
        {
            var settings = Activator.CreateInstance(type);

            foreach (var prop in type.GetProperties())
            {
                if (!prop.CanRead || !prop.CanWrite)
                    continue;

                var key = type.Name + "." + prop.Name;
                var setting = GetSettingByKey<string>(key, storeId:storeId, loadSharedValueIfNotFound: true);
                if (setting == null)
                    continue;

                if (!TypeDescriptor.GetConverter(prop.PropertyType).CanConvertFrom(typeof(string)))
                    continue;

                if (!TypeDescriptor.GetConverter(prop.PropertyType).IsValid(setting))
                    continue;

                var value = TypeDescriptor.GetConverter(prop.PropertyType).ConvertFromInvariantString(setting);

                prop.SetValue(settings, value, null);

            }

            return settings as ISettings;
        }

        public void SaveSetting<T>(T settings, int storeId = 0) where T : ISettings, new()
        {
            throw new NotImplementedException();
        }

        public void SaveSetting<T, TPropType>(T settings, Expression<Func<T, TPropType>> keySelector, int storeId = 0, bool clearCache = true) where T : ISettings, new()
        {
            throw new NotImplementedException();
        }

        public void SaveSettingOverridablePerStore<T, TPropType>(T settings, Expression<Func<T, TPropType>> keySelector, bool overrideForStore, int storeId = 0, bool clearCache = true) where T : ISettings, new()
        {
            throw new NotImplementedException();
        }

        public void SetSetting<T>(string key, T value, int storeId = 0, bool clearCache = true)
        {
            throw new NotImplementedException();
        }

        public bool SettingExists<T, TPropType>(T settings, Expression<Func<T, TPropType>> keySelector, int storeId = 0) where T : ISettings, new()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Utilities

        protected virtual IDictionary<string, IList<SettingForCaching>> GetAllSettingsCached()
        {
            return _cacheManager.Get(NopConfigurationDefaults.SettingsAllCacheKey, () =>
            {
                var query = from s in _settingRepository.TableNoTracking
                            orderby s.Name, s.StoreId
                            select s;
                var settings = query.ToList();
                var dictionary = new Dictionary<string, IList<SettingForCaching>>();
                foreach (var s in settings)
                {
                    var resourceName = s.Name.ToLowerInvariant();
                    var settingForCaching = new SettingForCaching
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Value = s.Value,
                        StoreId = s.StoreId
                    };
                    if (!dictionary.ContainsKey(resourceName))
                    {
                        //first setting
                        dictionary.Add(resourceName, new List<SettingForCaching>
                        {
                            settingForCaching
                        });
                    }
                    else
                    {
                        //already added
                        //most probably it's the setting with the same name but for some certain store (storeId > 0)
                        dictionary[resourceName].Add(settingForCaching);
                    }
                }

                return dictionary;
            });
        }

        #endregion

        #region Nested Class

        [Serializable]
        public class SettingForCaching
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
            public int StoreId { get; set; }

        }

        #endregion
    }
}
