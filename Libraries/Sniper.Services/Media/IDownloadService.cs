using Microsoft.AspNetCore.Http;
using Sniper.Core.Domain.Media;
using Sniper.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Media
{
    public partial interface IDownloadService
    {

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="downloadId"></param>
        /// <returns></returns>
        Download GetDownloadById(int downloadId);

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="downloadGuid"></param>
        /// <returns></returns>
        Download GetDownloadByGuid(Guid downloadGuid);

        /// <summary>
        /// 删除下载
        /// </summary>
        /// <param name="download"></param>
        void DeleteDownload(Download download);

        /// <summary>
        /// 插入下载
        /// </summary>
        /// <param name="download"></param>
        void InsertDownload(Download download);

        /// <summary>
        /// 更新下载
        /// </summary>
        /// <param name="download"></param>
        void UpdateDownload(Download download);

        /// <summary>
        /// 是否下载所有
        /// </summary>
        /// <param name="orderItem"></param>
        /// <returns></returns>
        bool IsDownloadAllowed(OrderItem orderItem);

        /// <summary>
        /// 是否允许下载许可证
        /// </summary>
        /// <param name="orderItem"></param>
        /// <returns></returns>
        bool IsLicenseDownloadAllowed(OrderItem orderItem);

        /// <summary>
        /// 下载二进制数组
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        byte[] GetDownloadBits(IFormFile file);

    }
}
