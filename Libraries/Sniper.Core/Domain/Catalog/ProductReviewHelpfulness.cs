using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    /// <summary>
    /// 有效评论
    /// </summary>
    public partial class ProductReviewHelpfulness : BaseEntity
    {
        /// <summary>
        /// 评论标识符
        /// </summary>
        public int ProductReviewId { get; set; }

        /// <summary>
        /// 评论是否有帮助
        /// </summary>
        public bool WasHelpful { get; set; }

        /// <summary>
        /// 客户标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 产品标识符
        /// </summary>
        public virtual ProductReview ProductReview { get; set; }


    }
}
