using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Web.Framework.UI.Paging
{
    public interface IPageableModel
    {
        /// <summary>
        /// 开始索引
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// 页面索引
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// 页面大小
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// 总数
        /// </summary>
        int TotalItems { get; }

        /// <summary>
        /// 总页数
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// 第一项
        /// </summary>
        int FirstItem { get; }

        /// <summary>
        /// 上一项
        /// </summary>
        int LastItem { get; }

        /// <summary>
        /// 前页是否存在
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// 下一页是否存在
        /// </summary>
        bool HasNextPage { get; }

    }

    public interface IPagination<T> : IPageableModel
    {

    }
}
