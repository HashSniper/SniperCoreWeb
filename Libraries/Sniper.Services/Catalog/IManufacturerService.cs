using Sniper.Core;
using Sniper.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Catalog
{
    /// <summary>
    /// 制造商服务
    /// </summary>
    public partial interface IManufacturerService
    {
        /// <summary>
        /// 删除制造商
        /// </summary>
        /// <param name="manufacturer"></param>
        void DeleteManufacturer(Manufacturer manufacturer);

        /// <summary>
        /// 获取制造商
        /// </summary>
        /// <param name="manufacturerName"></param>
        /// <param name="storeId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IPagedList<Manufacturer> GetAllManufacturers(string manufacturerName = "",
            int storeId = 0,
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            bool showHidden = false);

        /// <summary>
        /// 获取制造商
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <returns></returns>
        Manufacturer GetManufacturerById(int manufacturerId);

        /// <summary>
        /// 插入制造商
        /// </summary>
        /// <param name="manufacturer"></param>
        void InsertManufacturer(Manufacturer manufacturer);

        /// <summary>
        /// 更新制造商
        /// </summary>
        /// <param name="manufacturer"></param>
        void UpdateManufacturer(Manufacturer manufacturer);

        /// <summary>
        /// 删除产品制造商映射
        /// </summary>
        /// <param name="productManufacturer"></param>
        void DeleteProductManufacturer(ProductManufacturer productManufacturer);

        /// <summary>
        /// 获取产品制造商映射
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IPagedList<ProductManufacturer> GetProductManufacturersByManufacturerId(int manufacturerId,
         int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

        /// <summary>
        /// 获取产品制造商
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IList<ProductManufacturer> GetProductManufacturersByProductId(int productId, bool showHidden = false);

        /// <summary>
        /// 获取产品制造商
        /// </summary>
        /// <param name="productManufacturerId"></param>
        /// <returns></returns>
        ProductManufacturer GetProductManufacturerById(int productManufacturerId);

        /// <summary>
        /// 插入产品制造商
        /// </summary>
        /// <param name="productManufacturer"></param>
        void InsertProductManufacturer(ProductManufacturer productManufacturer);

        /// <summary>
        /// 更新产品制造商
        /// </summary>
        /// <param name="productManufacturer"></param>
        void UpdateProductManufacturer(ProductManufacturer productManufacturer);

        /// <summary>
        /// 获取产品的制造商ID
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        IDictionary<int, int[]> GetProductManufacturerIds(int[] productIds);

        /// <summary>
        /// 不存在的制造商的名单
        /// </summary>
        /// <param name="manufacturerIdsNames"></param>
        /// <returns></returns>
        string[] GetNotExistingManufacturers(string[] manufacturerIdsNames);

        /// <summary>
        /// 具有指定值的产品制造商
        /// </summary>
        /// <param name="source"></param>
        /// <param name="productId"></param>
        /// <param name="manufacturerId"></param>
        /// <returns></returns>
        ProductManufacturer FindProductManufacturer(IList<ProductManufacturer> source, int productId, int manufacturerId);

    }
}
