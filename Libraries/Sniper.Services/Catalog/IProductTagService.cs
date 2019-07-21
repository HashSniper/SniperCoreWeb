using Sniper.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Catalog
{
    /// <summary>
    /// 产品标签接口
    /// </summary>
    public partial interface IProductTagService
    {
        /// <summary>
        /// 删除产品标签
        /// </summary>
        /// <param name="productTag"></param>
        void DeleteProductTag(ProductTag productTag);

        /// <summary>
        /// 获取所有产品标签
        /// </summary>
        /// <returns></returns>
        IList<ProductTag> GetAllProductTags();

        /// <summary>
        /// 获取产品标签
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        IList<ProductTag> GetAllProductTagsByProductId(int productId);

        /// <summary>
        /// GetProductTagById
        /// </summary>
        /// <param name="productTagId"></param>
        /// <returns></returns>
        ProductTag GetProductTagById(int productTagId);

        /// <summary>
        /// GetProductTagByName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ProductTag GetProductTagByName(string name);

        /// <summary>
        /// 插入产品标签
        /// </summary>
        /// <param name="productTag"></param>
        void InsertProductTag(ProductTag productTag);

        /// <summary>
        /// 更新产品标签
        /// </summary>
        /// <param name="productTag"></param>
        void UpdateProductTag(ProductTag productTag);

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="productTagId"></param>
        /// <param name="storeId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        int GetProductCount(int productTagId, int storeId, bool showHidden = false);

        /// <summary>
        /// 更新标签
        /// </summary>
        /// <param name="product"></param>
        /// <param name="productTags"></param>
        void UpdateProductTags(Product product, string[] productTags);

    }
}
