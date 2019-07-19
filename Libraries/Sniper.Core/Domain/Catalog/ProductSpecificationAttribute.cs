using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    /// <summary>
    /// 表示产品规范属性
    /// </summary>
    public partial class ProductSpecificationAttribute : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 产品标识符
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 属性类型ID
        /// </summary>
        public int AttributeTypeId { get; set; }

        /// <summary>
        /// 规范属性标识符
        /// </summary>
        public int SpecificationAttributeOptionId { get; set; }

        /// <summary>
        /// 自定义值
        /// </summary>
        public string CustomValue { get; set; }

        /// <summary>
        /// 是否可以过滤属性
        /// </summary>
        public bool AllowFiltering { get; set; }

        /// <summary>
        /// 该属性是否将显示在产品页面上
        /// </summary>
        public bool ShowOnProductPage { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 规范属性选项
        /// </summary>
        public virtual SpecificationAttributeOption SpecificationAttributeOption { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        public SpecificationAttributeType AttributeType
        {
            get => (SpecificationAttributeType)AttributeTypeId;
            set => AttributeTypeId = (int)value;
        }
    }
}
