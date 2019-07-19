using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Orders
{
    /// <summary>
    /// 表示购物车项目
    /// </summary>
    public partial class ShoppingCartItem : BaseEntity
    {
        /// <summary>
        /// 商店id
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 购物车类型标识符
        /// </summary>
        public int ShoppingCartTypeId { get; set; }

        /// <summary>
        /// the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 产品标识符
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// XML格式的产品属性
        /// </summary>
        public string AttributesXml { get; set; }

        /// <summary>
        /// 价格由客户输入
        /// </summary>
        public decimal CustomerEnteredPrice { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 租赁产品的开始日期（如果不是租赁产品，则为null）
        /// </summary>
        public DateTime? RentalStartDateUtc { get; set; }

        /// <summary>
        /// 租赁产品结束日期（如果不是租赁产品，则为null）
        /// </summary>
        public DateTime? RentalEndDateUtc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 日志类型
        /// </summary>
        public ShoppingCartType ShoppingCartType
        {
            get => (ShoppingCartType)ShoppingCartTypeId;
            set => ShoppingCartTypeId = (int)value;
        }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }

    }
}
