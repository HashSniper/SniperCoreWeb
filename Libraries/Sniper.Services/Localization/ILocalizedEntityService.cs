using Sniper.Core;
using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sniper.Services.Localization
{
    public partial interface ILocalizedEntityService
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="localizedProperty"></param>
        void DeleteLocalizedProperty(LocalizedProperty localizedProperty);

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="localizedPropertyId"></param>
        /// <returns></returns>
        LocalizedProperty GetLocalizedPropertyById(int localizedPropertyId);

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="languageId"></param>
        /// <param name="entityId"></param>
        /// <param name="localeKeyGroup"></param>
        /// <param name="localeKey"></param>
        /// <returns></returns>
        string GetLocalizedValue(int languageId, int entityId, string localeKeyGroup, string localeKey);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="localizedProperty"></param>
        void InsertLocalizedProperty(LocalizedProperty localizedProperty);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="localizedProperty"></param>
        void UpdateLocalizedProperty(LocalizedProperty localizedProperty);

        /// <summary>
        /// 保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="keySelector"></param>
        /// <param name="localeValue"></param>
        /// <param name="languageId"></param>
        void SaveLocalizedValue<T>(T entity,
                Expression<Func<T, string>> keySelector,
                string localeValue,
                int languageId) where T : BaseEntity, ILocalizedEntity;

        /// <summary>
        /// 保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TPropType"></typeparam>
        /// <param name="entity"></param>
        /// <param name="keySelector"></param>
        /// <param name="localeValue"></param>
        /// <param name="languageId"></param>
        void SaveLocalizedValue<T, TPropType>(T entity,
               Expression<Func<T, TPropType>> keySelector,
               TPropType localeValue,
               int languageId) where T : BaseEntity, ILocalizedEntity;
    }
}
