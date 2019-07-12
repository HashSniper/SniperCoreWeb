using Sniper.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Logging
{
    public partial class Log:BaseEntity
    {
        /// <summary>
        /// 日志级别标志
        /// </summary>
        public int LogLevelId { get; set; }

        /// <summary>
        /// 异常详细信息
        /// </summary>
        public string FullMessage { get; set; }

        /// <summary>
        /// ip地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 识别符
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// 页面url
        /// </summary>
        public string PageUrl { get; set; }

        /// <summary>
        /// 引用url
        /// </summary>
        public string ReferrerUrl { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 日志级别
        /// </summary>
        public LogLevel LogLevel {
            get => (LogLevel)LogLevelId;
            set => LogLevelId = (int)value;
        }
        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }


    }
}
