using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    /// <summary>
    /// 表示产品评审和审核类型映射
    /// </summary>
    public partial class ProductReviewReviewTypeMapping : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 评论标识符
        /// </summary>
        public int ProductReviewId { get; set; }

        /// <summary>
        /// 评论类型标识符
        /// </summary>
        public int ReviewTypeId { get; set; }

        /// <summary>
        /// 评分
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public virtual ProductReview ProductReview { get; set; }

        /// <summary>
        /// 评论类型
        /// </summary>
        public virtual ReviewType ReviewType { get; set; }

    }
}
