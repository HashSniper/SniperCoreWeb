using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Media
{
    /// <summary>
    /// 媒体设置
    /// </summary>
    public class MediaSettings : ISettings
    {
        /// <summary>
        /// 客户头像的图片大小（如果已启用）
        /// </summary>
        public int AvatarPictureSize { get; set; }

        /// <summary>
        /// 目录页面上显示的产品图片大拇指的图片大小（例如类别详细信息页面）
        /// </summary>
        public int ProductThumbPictureSize { get; set; }

        /// <summary>
        /// 产品详细信息页面上显示的主要产品图片的图片大小
        /// </summary>
        public int ProductDetailsPictureSize { get; set; }

        /// <summary>
        /// 产品图片的图片大小显示在产品详细信息页面上
        /// </summary>
        public int ProductThumbPictureSizeOnProductDetailsPage { get; set; }

        /// <summary>
        /// 相关产品图片的图片大小
        /// </summary>
        public int AssociatedProductPictureSize { get; set; }

        /// <summary>
        /// 类别图片的图片大小
        /// </summary>
        public int CategoryThumbPictureSize { get; set; }

        /// <summary>
        /// 制造商图片的图片大小
        /// </summary>
        public int ManufacturerThumbPictureSize { get; set; }

        /// <summary>
        /// 供应商图片的图片大小
        /// </summary>
        public int VendorThumbPictureSize { get; set; }

        /// <summary>
        /// 购物车页面上的产品图片的图片大小
        /// </summary>
        public int CartThumbPictureSize { get; set; }

        /// <summary>
        /// 迷你购物车图片大小
        /// </summary>
        public int MiniCartThumbPictureSize { get; set; }

        /// <summary>
        /// 自动填充搜索框的产品图片的图片大小
        /// </summary>
        public int AutoCompleteSearchThumbPictureSize { get; set; }

        /// <summary>
        /// 产品详细信息页面上图像正方形的图片大小（与“图像正方形”属性类型一起使用
        /// </summary>
        public int ImageSquarePictureSize { get; set; }

        /// <summary>
        /// 是否启用图片缩放
        /// </summary>
        public bool DefaultPictureZoomEnabled { get; set; }

        /// <summary>
        /// 允许的最大图片大小。 如果上传了更大的图片，那么它将被调整大小
        /// </summary>
        public int MaximumImageSize { get; set; }

        /// <summary>
        /// 用于图像生成的默认质量
        /// </summary>
        public int DefaultImageQuality { get; set; }

        /// <summary>
        /// 是单个（/ content / images / thumbs /）还是多个（/ content / images / thumbs / 001 /和/ content / images / thumbs / 002 /）目录将用于图片大拇指
        /// </summary>
        public bool MultipleThumbDirectories { get; set; }

        /// <summary>
        /// 我们是否应该使用快速HASHBYTES（哈希和）数据库函数来比较导入产品时的图片
        /// </summary>
        public bool ImportProductImagesUsingHash { get; set; }

        /// <summary>
        /// Azure CacheControl标头（例如“max-age = 3600，public”）
        /// </summary>
        public string AzureCacheControlHeader { get; set; }

        /// <summary>
        /// 是否需要使用绝对图片路径
        /// </summary>
        public bool UseAbsoluteImagePath { get; set; }

    }
}
