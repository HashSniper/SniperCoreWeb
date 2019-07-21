using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Orders;
using Sniper.Web.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sniper.Web.Factories
{
    /// <summary>
    /// 表示产品模型工厂的接口
    /// </summary>
    public partial interface IProductModelFactory
    {
        /// <summary>
        /// 产品模板视图路径
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        string PrepareProductTemplateViewPath(Product product);

        /// <summary>
        /// 准备产品概述模型
        /// </summary>
        /// <param name="products"></param>
        /// <param name="preparePriceModel"></param>
        /// <param name="preparePictureModel"></param>
        /// <param name="productThumbPictureSize"></param>
        /// <param name="prepareSpecificationAttributes"></param>
        /// <param name="forceRedirectionAfterAddingToCart"></param>
        /// <returns></returns>
        IEnumerable<ProductOverviewModel> PrepareProductOverviewModels(IEnumerable<Product> products,
            bool preparePriceModel = true, bool preparePictureModel = true,
            int? productThumbPictureSize = null, bool prepareSpecificationAttributes = false,
            bool forceRedirectionAfterAddingToCart = false);

        /// <summary>
        /// 准备产品详细信息模型
        /// </summary>
        /// <param name="product"></param>
        /// <param name="updatecartitem"></param>
        /// <param name="isAssociatedProduct"></param>
        /// <returns></returns>
        ProductDetailsModel PrepareProductDetailsModel(Product product, ShoppingCartItem updatecartitem = null, bool isAssociatedProduct = false);

        /// <summary>
        /// 准备产品评论模型
        /// </summary>
        /// <param name="model"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        ProductReviewsModel PrepareProductReviewsModel(ProductReviewsModel model, Product product);

        /// <summary>
        /// 准备客户产品评论模型
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        CustomerProductReviewsModel PrepareCustomerProductReviewsModel(int? page);

        /// <summary>
        /// 准备产品电子邮件的朋友模型
        /// </summary>
        /// <param name="model"></param>
        /// <param name="product"></param>
        /// <param name="excludeProperties"></param>
        /// <returns></returns>
        ProductEmailAFriendModel PrepareProductEmailAFriendModel(ProductEmailAFriendModel model, Product product, bool excludeProperties);

        /// <summary>
        /// 准备产品规格型号
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        IList<ProductSpecificationModel> PrepareProductSpecificationModel(Product product);


    }
}
