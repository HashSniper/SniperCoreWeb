using Sniper.Core.Configuration;
using Sniper.Core.Domain.Configuration;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sniper.Services.Configuration
{
    public partial interface ISettingService
    {
        /// <summary>
        /// id
        /// </summary>
        /// <param name="settingId"></param>
        /// <returns></returns>
        Setting GetSettingById(int settingId);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="setting"></param>
        void DeleteSetting(Setting setting);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="settings"></param>
        void DeleteSettings(IList<Setting> settings);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <param name="storeId"></param>
        /// <param name="loadSharedValueIfNotFound"></param>
        /// <returns></returns>
        Setting GetSetting(string key, int storeId = 0, bool loadSharedValueIfNotFound = false);

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <param name="storeId"></param>
        /// <param name="loadSharedValueIfNotFound"></param>
        /// <returns></returns>
        T GetSettingByKey<T>(string key, T defaultValue = default(T), int storeId = 0, bool loadSharedValueIfNotFound = false);

        /// <summary>
        /// 设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="storeId"></param>
        /// <param name="clearCache"></param>
        void SetSetting<T>(string key, T value, int storeId = 0, bool clearCache = true);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        IList<Setting> GetAllSettings();

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TPropType"></typeparam>
        /// <param name="settings"></param>
        /// <param name="keySelector"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        bool SettingExists<T, TPropType>(T settings,Expression<Func<T, TPropType>> keySelector, int storeId = 0) where T : ISettings, new();

        /// <summary>
        /// 加载
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeId"></param>
        /// <returns></returns>
        T LoadSetting<T>(int storeId = 0) where T : ISettings, new();

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="type"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        ISettings LoadSetting(Type type, int storeId = 0);

        /// <summary>
        /// 保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="settings"></param>
        /// <param name="storeId"></param>
        void SaveSetting<T>(T settings, int storeId = 0) where T : ISettings, new();

        /// <summary>
        /// 保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TPropType"></typeparam>
        /// <param name="settings"></param>
        /// <param name="keySelector"></param>
        /// <param name="storeId"></param>
        /// <param name="clearCache"></param>
        void SaveSetting<T, TPropType>(T settings,Expression<Func<T, TPropType>> keySelector,int storeId = 0, bool clearCache = true) where T : ISettings, new();

        /// <summary>
        /// 保存设置对象（每个商店）。 如果每个商店没有覆盖该设置，那么它将被删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TPropType"></typeparam>
        /// <param name="settings"></param>
        /// <param name="keySelector"></param>
        /// <param name="overrideForStore"></param>
        /// <param name="storeId"></param>
        /// <param name="clearCache"></param>
        void SaveSettingOverridablePerStore<T, TPropType>(T settings,Expression<Func<T, TPropType>> keySelector,bool overrideForStore, int storeId = 0, bool clearCache = true) where T : ISettings, new();

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void DeleteSetting<T>() where T : ISettings, new();

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TPropType"></typeparam>
        /// <param name="settings"></param>
        /// <param name="keySelector"></param>
        /// <param name="storeId"></param>
        void DeleteSetting<T, TPropType>(T settings,Expression<Func<T, TPropType>> keySelector, int storeId = 0) where T : ISettings, new();

        /// <summary>
        /// 清除缓存
        /// </summary>
        void ClearCache();

        /// <summary>
        /// Get setting key (stored into database)
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="settings"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        string GetSettingKey<TSettings, T>(TSettings settings, Expression<Func<TSettings, T>> keySelector) where TSettings : ISettings, new();

    }
}
