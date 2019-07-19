using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    public partial class ProductAttributeMapping : BaseEntity, ILocalizedEntity
    {
        private ICollection<ProductAttributeValue> _productAttributeValues;

        /// <summary>
        /// 产品标识符
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 产品属性标识符
        /// </summary>
        public int ProductAttributeId { get; set; }

        /// <summary>
        /// 文本提示
        /// </summary>
        public string TextPrompt { get; set; }

        /// <summary>
        /// 是否需要该实体
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// 属性控件类型标识符
        /// </summary>
        public int AttributeControlTypeId { get; set; }

        /// <summary>
        /// 展示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 最小长度的验证规则（对于文本框和多行文本框）
        /// </summary>
        public int? ValidationMinLength { get; set; }

        /// <summary>
        /// 最大长度的验证规则（对于文本框和多行文本框）
        /// </summary>
        public int? ValidationMaxLength { get; set; }

        /// <summary>
        /// 文件允许扩展的验证规则（用于文件上传）
        /// </summary>
        public string ValidationFileAllowedExtensions { get; set; }

        /// <summary>
        /// 文件最大大小的验证规则，以千字节为单位（用于文件上传）
        /// </summary>
        public int? ValidationFileMaximumSize { get; set; }

        /// <summary>
        /// 默认值（对于文本框和多行文本框）
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 应该启用此属性（可见）时的条件（取决于其他属性）。
        /// </summary>
        public string ConditionAttributeXml { get; set; }

        /// <summary>
        /// 属性控件类型
        /// </summary>
        public AttributeControlType AttributeControlType
        {
            get => (AttributeControlType)AttributeControlTypeId;
            set => AttributeControlTypeId = (int)value;
        }
        
        /// <summary>
        /// 产品属性
        /// </summary>
        public virtual ProductAttribute ProductAttribute { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 产品属性值
        /// </summary>
        public virtual ICollection<ProductAttributeValue> ProductAttributeValues
        {
            get => _productAttributeValues ?? (_productAttributeValues = new List<ProductAttributeValue>());
            protected set => _productAttributeValues = value;
        }

    }
}
