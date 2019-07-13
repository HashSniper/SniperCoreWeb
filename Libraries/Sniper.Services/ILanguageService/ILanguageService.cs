using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.ILanguageService
{
    public partial interface ILanguageService
    {
        /// <summary>
        /// 删除语言
        /// </summary>
        /// <param name="language"></param>
        void DeleteLanguage(Language language);

        /// <summary>
        /// 获取所有语言
        /// </summary>
        /// <param name="showHidden"></param>
        /// <param name="storeId"></param>
        /// <param name="loadCacheableCopy"></param>
        /// <returns></returns>
        IList<Language> GetAllLanguages(bool showHidden = false, int storeId = 0, bool loadCacheableCopy = true);

        /// <summary>
        /// 通过id获取语言
        /// </summary>
        /// <param name="languageId"></param>
        /// <param name="loadCacheableCopy"></param>
        /// <returns></returns>
        Language GetLanguageById(int languageId, bool loadCacheableCopy = true);

        /// <summary>
        /// 插入语言
        /// </summary>
        /// <param name="language"></param>
        void InsertLanguage(Language language);

        /// <summary>
        /// 更新语言
        /// </summary>
        /// <param name="language"></param>
        void UpdateLanguage(Language language);

        /// <summary>
        /// 获得2个字母的ISO语言代码
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        string GetTwoLetterIsoLanguageName(Language language); 
    }
}
