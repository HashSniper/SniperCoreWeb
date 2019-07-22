using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Media
{
    public partial class Download : BaseEntity
    {
        /// <summary>
        /// guid
        /// </summary>
        public Guid DownloadGuid { get; set; }

        /// <summary>
        /// 是否应使用DownloadUrl属性
        /// </summary>
        public bool UseDownloadUrl { get; set; }

        /// <summary>
        /// 下载连接
        /// </summary>
        public string DownloadUrl { get; set; }

        /// <summary>
        /// 下载二进制文件
        /// </summary>
        public byte[] DownloadBinary { get; set; }

        /// <summary>
        /// 下载的mime-type
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// 下载是否是新的
        /// </summary>
        public bool IsNew { get; set; }


    }
}
