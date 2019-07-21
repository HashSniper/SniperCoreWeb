using Microsoft.AspNetCore.Http;
using Sniper.Core;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Media
{
    /// <summary>
    /// 图片服务
    /// </summary>
    public partial interface IPictureService
    {
        /// <summary>
        /// 来自mime类型的文件扩展名。
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        string GetFileExtensionFromMimeType(string mimeType);

        /// <summary>
        /// 加载的图片二进制文件取决于图片存储设置
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        byte[] LoadPictureBinary(Picture picture);

        /// <summary>
        /// 获取图片名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string GetPictureSeName(string name);

        /// <summary>
        /// 默认图片网址
        /// </summary>
        /// <param name="targetSize"></param>
        /// <param name="defaultPictureType"></param>
        /// <param name="storeLocation"></param>
        /// <returns></returns>
        string GetDefaultPictureUrl(int targetSize = 0,
            PictureType defaultPictureType = PictureType.Entity,
            string storeLocation = null);

        /// <summary>
        /// 获取图片url
        /// </summary>
        /// <param name="pictureId"></param>
        /// <param name="targetSize"></param>
        /// <param name="showDefaultPicture"></param>
        /// <param name="storeLocation"></param>
        /// <param name="defaultPictureType"></param>
        /// <returns></returns>
        string GetPictureUrl(int pictureId,
            int targetSize = 0,
            bool showDefaultPicture = true,
            string storeLocation = null,
            PictureType defaultPictureType = PictureType.Entity);

        /// <summary>
        /// 获取图片路径
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="targetSize"></param>
        /// <param name="showDefaultPicture"></param>
        /// <param name="storeLocation"></param>
        /// <param name="defaultPictureType"></param>
        /// <returns></returns>
        string GetPictureUrl(Picture picture,
            int targetSize = 0,
            bool showDefaultPicture = true,
            string storeLocation = null,
            PictureType defaultPictureType = PictureType.Entity);

        /// <summary>
        /// 获取图片本地路径
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="targetSize"></param>
        /// <param name="showDefaultPicture"></param>
        /// <returns></returns>
        string GetThumbLocalPath(Picture picture, int targetSize = 0, bool showDefaultPicture = true);

        /// <summary>
        /// 通过id获取图片
        /// </summary>
        /// <param name="pictureId"></param>
        /// <returns></returns>
        Picture GetPictureById(int pictureId);

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="picture"></param>
        void DeletePicture(Picture picture);

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPagedList<Picture> GetPictures(string virtualPath = "", int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// 获取所有图片
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="recordsToReturn"></param>
        /// <returns></returns>
        IList<Picture> GetPicturesByProductId(int productId, int recordsToReturn = 0);

        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="pictureBinary"></param>
        /// <param name="mimeType"></param>
        /// <param name="seoFilename"></param>
        /// <param name="altAttribute"></param>
        /// <param name="titleAttribute"></param>
        /// <param name="isNew"></param>
        /// <param name="validateBinary"></param>
        /// <returns></returns>
        Picture InsertPicture(byte[] pictureBinary, string mimeType, string seoFilename,
            string altAttribute = null, string titleAttribute = null,
            bool isNew = true, bool validateBinary = true);

        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="defaultFileName"></param>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        Picture InsertPicture(IFormFile formFile, string defaultFileName = "", string virtualPath = "");

        /// <summary>
        /// 更新图片
        /// </summary>
        /// <param name="pictureId"></param>
        /// <param name="pictureBinary"></param>
        /// <param name="mimeType"></param>
        /// <param name="seoFilename"></param>
        /// <param name="altAttribute"></param>
        /// <param name="titleAttribute"></param>
        /// <param name="isNew"></param>
        /// <param name="validateBinary"></param>
        /// <returns></returns>
        Picture UpdatePicture(int pictureId, byte[] pictureBinary, string mimeType,
            string seoFilename, string altAttribute = null, string titleAttribute = null,
            bool isNew = true, bool validateBinary = true);

        /// <summary>
        /// 更新图片
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        Picture UpdatePicture(Picture picture);

        /// <summary>
        /// 更新图片的SEO文件名
        /// </summary>
        /// <param name="pictureId"></param>
        /// <param name="seoFilename"></param>
        /// <returns></returns>
        Picture SetSeoFilename(int pictureId, string seoFilename);

        /// <summary>
        /// 验证输入图片尺寸
        /// </summary>
        /// <param name="pictureBinary"></param>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        byte[] ValidatePicture(byte[] pictureBinary, string mimeType);

        /// <summary>
        /// 是否应将图像存储在数据库中。
        /// </summary>
        bool StoreInDb { get; set; }

        /// <summary>
        /// 获取图片哈希
        /// </summary>
        /// <param name="picturesIds"></param>
        /// <returns></returns>
        IDictionary<int, string> GetPicturesHash(int[] picturesIds);

        /// <summary>
        /// 获取产品图片（购物车和订单详情页面）
        /// </summary>
        /// <param name="product"></param>
        /// <param name="attributesXml"></param>
        /// <returns></returns>
        Picture GetProductPicture(Product product, string attributesXml);

    }
}
