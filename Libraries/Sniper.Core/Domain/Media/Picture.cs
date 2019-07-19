using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Media
{
    public partial class Picture : BaseEntity
    {
        /// <summary>
        /// 图片mime类型
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// 图片的SEO友好文件名
        /// </summary>
        public string SeoFilename { get; set; }

        /// <summary>
        /// “img”HTML元素的“alt”属性。 如果为空，则将使用默认规则（例如产品名称）
        /// </summary>
        public string AltAttribute { get; set; }

        /// <summary>
        /// title标签
        /// </summary>
        public string TitleAttribute { get; set; }

        /// <summary>
        /// 是否为新图片
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// 图片二进制
        /// </summary>
        public virtual PictureBinary PictureBinary { get; set; }

        /// <summary>
        /// 虚拟路径
        /// </summary>
        public string VirtualPath { get; set; }

    }
}
