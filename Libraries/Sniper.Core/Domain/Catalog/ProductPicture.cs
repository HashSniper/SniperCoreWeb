using Sniper.Core.Domain.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    /// <summary>
    /// 表示产品图片映射
    /// </summary>
    public partial class ProductPicture : BaseEntity
    {
        /// <summary>
        /// 产品标识符
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 图片标识符
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 展示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public virtual Picture Picture { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Product Product { get; set; }

    }
}
