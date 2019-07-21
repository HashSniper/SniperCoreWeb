using Sniper.Core;
using Sniper.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Catalog
{
    /// <summary>
    /// 规范属性服务接口
    /// </summary>
    public partial interface ISpecificationAttributeService
    {
        /// <summary>
        /// 获取规范属性
        /// </summary>
        /// <param name="specificationAttributeId"></param>
        /// <returns></returns>
        SpecificationAttribute GetSpecificationAttributeById(int specificationAttributeId);

        /// <summary>
        /// 获取规范属性
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPagedList<SpecificationAttribute> GetSpecificationAttributes(int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// 获取所有规范属性
        /// </summary>
        /// <returns></returns>
        IList<SpecificationAttribute> GetSpecificationAttributesWithOptions();


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="specificationAttribute"></param>
        void DeleteSpecificationAttribute(SpecificationAttribute specificationAttribute);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="specificationAttribute"></param>
        void InsertSpecificationAttribute(SpecificationAttribute specificationAttribute);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="specificationAttribute"></param>
        void UpdateSpecificationAttribute(SpecificationAttribute specificationAttribute);

        /// <summary>
        /// 获取规范属性选项
        /// </summary>
        /// <param name="specificationAttributeOption"></param>
        /// <returns></returns>
        SpecificationAttributeOption GetSpecificationAttributeOptionById(int specificationAttributeOption);

        /// <summary>
        /// 获取规范属性选项
        /// </summary>
        /// <param name="specificationAttributeOptionIds"></param>
        /// <returns></returns>
        IList<SpecificationAttributeOption> GetSpecificationAttributeOptionsByIds(int[] specificationAttributeOptionIds);

        /// <summary>
        /// 获取规范属性选项
        /// </summary>
        /// <param name="specificationAttributeId"></param>
        /// <returns></returns>
        IList<SpecificationAttributeOption> GetSpecificationAttributeOptionsBySpecificationAttribute(int specificationAttributeId);

        /// <summary>
        /// 删除规范属性选项
        /// </summary>
        /// <param name="specificationAttributeOption"></param>
        void DeleteSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption);

        /// <summary>
        /// 插入规范属性选项
        /// </summary>
        /// <param name="specificationAttributeOption"></param>
        void InsertSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption);
        
        /// <summary>
        /// 更新规范属性选项
        /// </summary>
        /// <param name="specificationAttributeOption"></param>
        void UpdateSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption);

        /// <summary>
        /// 获取不存在的规范属性选项
        /// </summary>
        /// <param name="attributeOptionIds"></param>
        /// <returns></returns>
        int[] GetNotExistingSpecificationAttributeOptions(int[] attributeOptionIds);

        /// <summary>
        /// 删除产品规范属性映射
        /// </summary>
        /// <param name="productSpecificationAttribute"></param>
        void DeleteProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute);

        /// <summary>
        /// 获取产品规范属性映射
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="specificationAttributeOptionId"></param>
        /// <param name="allowFiltering"></param>
        /// <param name="showOnProductPage"></param>
        /// <returns></returns>
        IList<ProductSpecificationAttribute> GetProductSpecificationAttributes(int productId = 0,
            int specificationAttributeOptionId = 0, bool? allowFiltering = null, bool? showOnProductPage = null);

        /// <summary>
        /// 获取产品规范属性映射
        /// </summary>
        /// <param name="productSpecificationAttributeId"></param>
        /// <returns></returns>
        ProductSpecificationAttribute GetProductSpecificationAttributeById(int productSpecificationAttributeId);

        /// <summary>
        /// 插入产品规范属性映射
        /// </summary>
        /// <param name="productSpecificationAttribute"></param>
        void InsertProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute);

        /// <summary>
        /// 更新产品规范属性映射
        /// </summary>
        /// <param name="productSpecificationAttribute"></param>
        void UpdateProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute);

        /// <summary>
        /// 获取产品规范属性映射数量
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="specificationAttributeOptionId"></param>
        /// <returns></returns>
        int GetProductSpecificationAttributeCount(int productId = 0, int specificationAttributeOptionId = 0);

        /// <summary>
        /// 获取产品规范属性映射
        /// </summary>
        /// <param name="specificationAttributeId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPagedList<Product> GetProductsBySpecificationAttributeId(int specificationAttributeId, int pageIndex, int pageSize);

    }
}
