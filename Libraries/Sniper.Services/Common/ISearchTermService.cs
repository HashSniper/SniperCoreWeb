using Sniper.Core;
using Sniper.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Common
{
    /// <summary>
    /// 搜索词服务接口
    /// </summary>
    public partial interface ISearchTermService
    {
        /// <summary>
        /// 删除搜索记录
        /// </summary>
        /// <param name="searchTerm"></param>
        void DeleteSearchTerm(SearchTerm searchTerm);

        /// <summary>
        /// 按标识符获取搜索项记录
        /// </summary>
        /// <param name="searchTermId"></param>
        /// <returns></returns>
        SearchTerm GetSearchTermById(int searchTermId);

        /// <summary>
        /// 按关键字获取搜索内容
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        SearchTerm GetSearchTermByKeyword(string keyword, int storeId);

        /// <summary>
        /// 获取搜索词统计信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPagedList<SearchTermReportLine> GetStats(int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// 插入搜索记录
        /// </summary>
        /// <param name="searchTerm"></param>
        void InsertSearchTerm(SearchTerm searchTerm);

        /// <summary>
        /// 更新搜索记录
        /// </summary>
        /// <param name="searchTerm"></param>
        void UpdateSearchTerm(SearchTerm searchTerm);

    }
}
