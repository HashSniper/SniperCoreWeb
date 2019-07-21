using Sniper.Core;
using Sniper.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Catalog
{
    public partial interface ICategoryService
    {
        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="category"></param>
        void DeleteCategory(Category category);

        /// <summary>
        /// 获取类别
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="showHidden"></param>
        /// <param name="loadCacheableCopy"></param>
        /// <returns></returns>
        IList<Category> GetAllCategories(int storeId = 0, bool showHidden = false, bool loadCacheableCopy = true);

        /// <summary>
        /// 获取类别
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="storeId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IPagedList<Category> GetAllCategories(string categoryName, int storeId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

        /// <summary>
        /// 获取按父类别标识符过滤的所有类别
        /// </summary>
        /// <param name="parentCategoryId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IList<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId, bool showHidden = false);

        /// <summary>
        /// 获取主页上显示的所有类别
        /// </summary>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IList<Category> GetAllCategoriesDisplayedOnHomepage(bool showHidden = false);

        /// <summary>
        /// 获取子类别标识符
        /// </summary>
        /// <param name="parentCategoryId"></param>
        /// <param name="storeId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IList<int> GetChildCategoryIds(int parentCategoryId, int storeId = 0, bool showHidden = false);

        /// <summary>
        /// 根据id获取类别
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Category GetCategoryById(int categoryId);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="category"></param>
        void InsertCategory(Category category);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="category"></param>
        void UpdateCategory(Category category);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="productCategory"></param>
        void DeleteProductCategory(ProductCategory productCategory);

        /// <summary>
        /// 获取产品类别映射集合
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IPagedList<ProductCategory> GetProductCategoriesByCategoryId(int categoryId,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

        /// <summary>
        /// 获取产品类别映射集合
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IList<ProductCategory> GetProductCategoriesByProductId(int productId, bool showHidden = false);

        /// <summary>
        /// 获取产品类别映射集合
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="storeId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IList<ProductCategory> GetProductCategoriesByProductId(int productId, int storeId, bool showHidden = false);

        /// <summary>
        /// 获取产品类别映射
        /// </summary>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        ProductCategory GetProductCategoryById(int productCategoryId);

        /// <summary>
        /// 插入产品类别
        /// </summary>
        /// <param name="productCategory"></param>
        void InsertProductCategory(ProductCategory productCategory);

        /// <summary>
        /// 更新产品类别
        /// </summary>
        /// <param name="productCategory"></param>
        void UpdateProductCategory(ProductCategory productCategory);

        /// <summary>
        /// 不存在的类别的名称列表
        /// </summary>
        /// <param name="categoryIdsNames"></param>
        /// <returns></returns>
        string[] GetNotExistingCategories(string[] categoryIdsNames);

        /// <summary>
        /// 获取产品的类别ID
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        IDictionary<int, int[]> GetProductCategoryIds(int[] productIds);

        /// <summary>
        /// 按标识符获取类别
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <returns></returns>
        List<Category> GetCategoriesByIds(int[] categoryIds);

        /// <summary>
        /// 对树表示的类别排序
        /// </summary>
        /// <param name="source"></param>
        /// <param name="parentId"></param>
        /// <param name="ignoreCategoriesWithoutExistingParent"></param>
        /// <returns></returns>
        IList<Category> SortCategoriesForTree(IList<Category> source, int parentId = 0,
             bool ignoreCategoriesWithoutExistingParent = false);

        /// <summary>
        /// 具有指定值的ProductCategory
        /// </summary>
        /// <param name="source"></param>
        /// <param name="productId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        ProductCategory FindProductCategory(IList<ProductCategory> source, int productId, int categoryId);

        /// <summary>
        /// 获取格式化的类别痕迹
        /// </summary>
        /// <param name="category"></param>
        /// <param name="allCategories"></param>
        /// <param name="separator"></param>
        /// <param name="languageId"></param>
        /// <returns></returns>
        string GetFormattedBreadCrumb(Category category, IList<Category> allCategories = null,
           string separator = ">>", int languageId = 0);

        /// <summary>
        /// 获取类别
        /// </summary>
        /// <param name="category"></param>
        /// <param name="allCategories"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IList<Category> GetCategoryBreadCrumb(Category category, IList<Category> allCategories = null, bool showHidden = false);

    }
}
