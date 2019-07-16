using Sniper.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Logging
{
    public partial class ActivityLog : BaseEntity
    {
        /// <summary>
        /// 标识符
        /// </summary>
        public int ActivityLogTypeId { get; set; }

        /// <summary>
        /// 实体id
        /// </summary>
        public int? EntityId { get; set; }

        /// <summary>
        /// 实体名称
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// 客户标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 活动注释
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 日志类型
        /// </summary>
        public virtual ActivityLogType ActivityLogType { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// ip
        /// </summary>
        public virtual string IpAddress { get; set; }

    }
}
