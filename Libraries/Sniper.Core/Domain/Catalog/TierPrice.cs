using Sniper.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    /// <summary>
    /// 表示层级价格
    /// </summary>
    public partial class TierPrice : BaseEntity
    {
        /// <summary>
        /// 铲平标识符
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商店标识符
        /// </summary>
        public int StoreId { get; set; }
        
        /// <summary>
        /// 顾客角色标识符
        /// </summary>
        public int? CustomerRoleId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 获取或设置UTC的开始日期和时间
        /// </summary>
        public DateTime? StartDateTimeUtc { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDateTimeUtc { get; set; }

        /// <summary>
        /// 铲平
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public virtual CustomerRole CustomerRole { get; set; }

    }
}
