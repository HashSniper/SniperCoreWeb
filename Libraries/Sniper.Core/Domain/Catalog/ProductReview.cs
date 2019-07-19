using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    /// <summary>
    /// 代表产品评论
    /// </summary>
    public partial class ProductReview : BaseEntity
    {
        private ICollection<ProductReviewHelpfulness> _productReviewHelpfulnessEntries;
        private ICollection<ProductReviewReviewTypeMapping> _productReviewReviewTypeMappingEntries;

        /// <summary>
        /// 顾客标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 产品标识符
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商店标识符
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 指示内容是否被批准
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string ReviewText { get; set; }

        /// <summary>
        /// 答复
        /// </summary>
        public string ReplyText { get; set; }

        /// <summary>
        /// 是否已通知客户回复审核
        /// </summary>
        public bool CustomerNotifiedOfReply { get; set; }

        /// <summary>
        /// 评分
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// 有用投票数
        /// </summary>
        public int HelpfulYesTotal { get; set; }

        /// <summary>
        /// 没用投票数
        /// </summary>
        public int HelpfulNoTotal { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 顾客
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 商店
        /// </summary>
        public virtual Store Store { get; set; }

        /// <summary>
        /// 产品评论有用的条目
        /// </summary>
        public virtual ICollection<ProductReviewHelpfulness> ProductReviewHelpfulnessEntries
        {
            get => _productReviewHelpfulnessEntries ?? (_productReviewHelpfulnessEntries = new List<ProductReviewHelpfulness>());
            protected set => _productReviewHelpfulnessEntries = value;
        }

        /// <summary>
        /// 产品评论的条目
        /// </summary>
        public virtual ICollection<ProductReviewReviewTypeMapping> ProductReviewReviewTypeMappingEntries
        {
            get { return _productReviewReviewTypeMappingEntries ?? (_productReviewReviewTypeMappingEntries = new List<ProductReviewReviewTypeMapping>()); }
            protected set { _productReviewReviewTypeMappingEntries = value; }
        }
    }
}
