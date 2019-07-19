using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Discounts
{
    public partial class Discount : BaseEntity
    {
        private ICollection<DiscountRequirement> _discountRequirements;
        private ICollection<DiscountCategoryMapping> _discountCategoryMappings;
        private ICollection<DiscountManufacturerMapping> _discountManufacturerMappings;
        private ICollection<DiscountProductMapping> _discountProductMappings;


        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public int DiscountTypeId { get; set; }

        /// <summary>
        /// 是否使用百分比
        /// </summary>
        public bool UsePercentage { get; set; }

        /// <summary>
        /// 折扣百分比
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        ///折扣金额
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        ///最大折扣金额（与“UsePercentage”一起使用）
        /// </summary>
        public decimal? MaximumDiscountAmount { get; set; }

        /// <summary>
        /// 折扣开始日期和时间
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// 折扣结束时间
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        /// 表示折扣是否需要优惠券代码的值
        /// </summary>
        public bool RequiresCouponCode { get; set; }

        /// <summary>
        ///  优惠券代码
        /// </summary>
        public string CouponCode { get; set; }

        /// <summary>
        /// 表示折扣是否可以与其他折扣同时使用的值（具有相同的折扣类型）
        /// </summary>
        public bool IsCumulative { get; set; }

        /// <summary>
        /// 折扣限制标识符
        /// </summary>
        public int DiscountLimitationId { get; set; }

        /// <summary>
        /// 折扣限制时间（当限制设置为“仅限N次”或“每个客户N次”时使用）
        /// </summary>
        public int LimitationTimes { get; set; }

        /// <summary>
        /// 可以打折的最大产品数量
        /// Used with "Assigned to products" or "Assigned to categories" type
        /// </summary>
        public int? MaximumDiscountedQuantity { get; set; }

        /// <summary>
        /// 是否应该应用于所有子类别或所选子类别
        /// Used with "Assigned to categories" type only.
        /// </summary>
        public bool AppliedToSubCategories { get; set; }

        /// <summary>
        /// 折扣类型
        /// </summary>
        public DiscountType DiscountType
        {
            get => (DiscountType)DiscountTypeId;
            set => DiscountTypeId = (int)value;
        }

        /// <summary>
        /// 折扣限制
        /// </summary>
        public DiscountLimitationType DiscountLimitation
        {
            get => (DiscountLimitationType)DiscountLimitationId;
            set => DiscountLimitationId = (int)value;
        }

        /// <summary>
        ///折扣要求
        /// </summary>
        public virtual ICollection<DiscountRequirement> DiscountRequirements
        {
            get => _discountRequirements ?? (_discountRequirements = new List<DiscountRequirement>());
            protected set => _discountRequirements = value;
        }

        /// <summary>
        /// 折扣类别映射
        /// </summary>
        public virtual ICollection<DiscountCategoryMapping> DiscountCategoryMappings
        {
            get => _discountCategoryMappings ?? (_discountCategoryMappings = new List<DiscountCategoryMapping>());
            protected set => _discountCategoryMappings = value;
        }

        /// <summary>
        /// 折扣制造商的映射
        /// </summary>
        public virtual ICollection<DiscountManufacturerMapping> DiscountManufacturerMappings
        {
            get => _discountManufacturerMappings ?? (_discountManufacturerMappings = new List<DiscountManufacturerMapping>());
            protected set => _discountManufacturerMappings = value;
        }

        /// <summary>
        /// 折扣产品映射
        /// </summary>
        public virtual ICollection<DiscountProductMapping> DiscountProductMappings
        {
            get => _discountProductMappings ?? (_discountProductMappings = new List<DiscountProductMapping>());
            protected set => _discountProductMappings = value;
        }

    }
}
