using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    /// <summary>
    /// 表示规范属性选项
    /// </summary>
    public partial class SpecificationAttributeOption : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 规范属性标识符
        /// </summary>
        public int SpecificationAttributeId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 颜色RGB值（当您想要显示“颜色方块”而不是文本时使用）
        /// </summary>
        public string ColorSquaresRgb { get; set; }

        /// <summary>
        /// 展示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 规范属性
        /// </summary>
        public virtual SpecificationAttribute SpecificationAttribute { get; set; }

    }
}
