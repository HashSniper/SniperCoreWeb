using Sniper.Core;
using Sniper.Core.Domain.Seo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Seo
{
    public partial interface IUrlRecordService
    {
        /// <summary>
        /// 删除URL记录
        /// </summary>
        /// <param name="urlRecord"></param>
        void DeleteUrlRecord(UrlRecord urlRecord);

        /// <summary>
        /// 删除url记录
        /// </summary>
        /// <param name="urlRecords"></param>
        void DeleteUrlRecords(IList<UrlRecord> urlRecords);

        /// <summary>
        /// 获取url记录
        /// </summary>
        /// <param name="urlRecordId"></param>
        /// <returns></returns>
        UrlRecord GetUrlRecordById(int urlRecordId);

        /// <summary>
        /// 插入url记录
        /// </summary>
        /// <param name="urlRecord"></param>
        void InsertUrlRecord(UrlRecord urlRecord);

        /// <summary>
        /// 更新url记录
        /// </summary>
        /// <param name="urlRecord"></param>
        void UpdateUrlRecord(UrlRecord urlRecord);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        UrlRecord GetBySlug(string slug);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        UrlRecordService.UrlRecordForCaching GetBySlugCached(string slug);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPagedList<UrlRecord> GetAllUrlRecords(string slug = "", int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// 查找slug
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="entityName"></param>
        /// <param name="languageId"></param>
        /// <returns></returns>
        string GetActiveSlug(int entityId, string entityName, int languageId);

        /// <summary>
        /// 保存slug
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="slug"></param>
        /// <param name="languageId"></param>
        void SaveSlug<T>(T entity, string slug, int languageId) where T : BaseEntity, ISlugSupported;

        /// <summary>
        /// 获取搜索引擎友好名称（slug）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="languageId"></param>
        /// <param name="returnDefaultValue"></param>
        /// <param name="ensureTwoPublishedLanguages"></param>
        /// <returns></returns>
        string GetSeName<T>(T entity, int? languageId = null, bool returnDefaultValue = true,
            bool ensureTwoPublishedLanguages = true) where T : BaseEntity, ISlugSupported;

        /// <summary>
        /// 获取搜索引擎友好名称（slug）
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="entityName"></param>
        /// <param name="languageId"></param>
        /// <param name="returnDefaultValue"></param>
        /// <param name="ensureTwoPublishedLanguages"></param>
        /// <returns></returns>
        string GetSeName(int entityId, string entityName, int? languageId = null,
            bool returnDefaultValue = true, bool ensureTwoPublishedLanguages = true);

        /// <summary>
        /// 获取 se名称
        /// </summary>
        /// <param name="name"></param>
        /// <param name="convertNonWesternChars"></param>
        /// <param name="allowUnicodeCharsInUrls"></param>
        /// <returns></returns>
        string GetSeName(string name, bool convertNonWesternChars, bool allowUnicodeCharsInUrls);

        /// <summary>
        /// 验证搜索引擎名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="seName"></param>
        /// <param name="name"></param>
        /// <param name="ensureNotEmpty"></param>
        /// <returns></returns>
        string ValidateSeName<T>(T entity, string seName, string name, bool ensureNotEmpty) where T : BaseEntity, ISlugSupported;

        /// <summary>
        /// 验证搜索引擎名称
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="entityName"></param>
        /// <param name="seName"></param>
        /// <param name="name"></param>
        /// <param name="ensureNotEmpty"></param>
        /// <returns></returns>
        string ValidateSeName(int entityId, string entityName, string seName, string name, bool ensureNotEmpty);

    }
}
