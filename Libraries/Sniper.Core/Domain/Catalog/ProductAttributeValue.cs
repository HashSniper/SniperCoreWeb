using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    /// <summary>
    /// 表示产品属性值
    /// </summary>
    public partial class ProductAttributeValue : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 产品属性映射标识符
        /// </summary>
        public int ProductAttributeMappingId { get; set; }

        /// <summary>
        /// 属性值类型标识符
        /// </summary>
        public int AttributeValueTypeId { get; set; }

        /// <summary>
        /// 关联的产品标识符（仅与AttributeValueType.AssociatedToProduct一起使用）
        /// </summary>
        public int AssociatedProductId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// RGB颜色值（与“颜色方块”属性类型一起使用）
        /// </summary>
        public string ColorSquaresRgb { get; set; }

        /// <summary>
        /// the picture ID for image square (used with "Image squares" attribute type)
        /// </summary>
        public int ImageSquaresPictureId { get; set; }

        /// <summary>
        /// 价格调整（仅用于AttributeValueType.Simple）
        /// </summary>
        public decimal PriceAdjustment { get; set; }

        /// <summary>
        /// “价格调整”是否指定为百分比（仅用于AttributeValueType.Simple）
        /// </summary>
        public bool PriceAdjustmentUsePercentage { get; set; }

        /// <summary>
        /// 权重调整（仅用于属性值类型。简单）
        /// </summary>
        public decimal WeightAdjustment { get; set; }

        /// <summary>
        /// 属性值cost（仅与AttributeValueType.Simple一起使用）
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        ///  whether the customer can enter the quantity of associated product (used only with AttributeValueType.AssociatedToProduct)
        /// </summary>
        public bool CustomerEntersQty { get; set; }

        /// <summary>
        /// 关联产品的数量（仅与AttributeValueType.AssociatedToProduct一起使用）
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 是否预先选择了该值
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// 展示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 图片标识符
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 产品属性映射
        /// </summary>
        public virtual ProductAttributeMapping ProductAttributeMapping { get; set; }

        /// <summary>
        /// 属性值类型
        /// </summary>
        public AttributeValueType AttributeValueType
        {
            get => (AttributeValueType)AttributeValueTypeId;
            set => AttributeValueTypeId = (int)value;
        }
    }
}
