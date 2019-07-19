using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Media
{
    public partial class PictureBinary : BaseEntity
    {
        /// <summary>
        /// 二进制数组
        /// </summary>
        public byte[] BinaryData { get; set; }

        /// <summary>
        /// 图片标识符
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public virtual Picture Picture { get; set; }

    }
}
