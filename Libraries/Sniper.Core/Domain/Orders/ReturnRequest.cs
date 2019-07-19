using Sniper.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Orders
{
    /// <summary>
    /// 表示返回请求
    /// </summary>
    public partial class ReturnRequest : BaseEntity
    {
        /// <summary>
        /// 自定义退货请求数
        /// </summary>
        public string CustomNumber { get; set; }

        /// <summary>
        /// 商店标识符
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 订单商品标识符
        /// </summary>
        public int OrderItemId { get; set; }

        /// <summary>
        /// 客户标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 退货的原因
        /// </summary>
        public string ReasonForReturn { get; set; }

        /// <summary>
        /// 请求
        /// </summary>
        public string RequestedAction { get; set; }

        /// <summary>
        /// 客户评论
        /// </summary>
        public string CustomerComments { get; set; }

        /// <summary>
        /// 客户上传的文件标识符（下载）
        /// </summary>
        public int UploadedFileId { get; set; }

        /// <summary>
        /// 工作人员指示
        /// </summary>
        public string StaffNotes { get; set; }

        /// <summary>
        /// 返回状态标识符
        /// </summary>
        public int ReturnRequestStatusId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 退货状态
        /// </summary>
        public ReturnRequestStatus ReturnRequestStatus
        {
            get => (ReturnRequestStatus)ReturnRequestStatusId;
            set => ReturnRequestStatusId = (int)value;
        }

        /// <summary>
        /// 顾客
        /// </summary>
        public virtual Customer Customer { get; set; }

    }
}
