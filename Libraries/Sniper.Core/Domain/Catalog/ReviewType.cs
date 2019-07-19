using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    /// <summary>
    /// 表示审核类型
    /// </summary>
    public partial class ReviewType : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 展示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 是否展示给顾客
        /// </summary>
        public bool VisibleToAllCustomers { get; set; }

        /// <summary>
        /// 是否需要审核类型
        /// </summary>
        public bool IsRequired { get; set; }

    }
}
