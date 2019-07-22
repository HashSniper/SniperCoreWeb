using Sniper.Core.Domain.Shipping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Shipping.Date
{
    /// <summary>
    /// 日期范围服务界面
    /// </summary>
    public partial interface IDateRangeService
    {
        /// <summary>
        /// 删除交货日期
        /// </summary>
        /// <param name="deliveryDate"></param>
        void DeleteDeliveryDate(DeliveryDate deliveryDate);

        /// <summary>
        /// 获取交货日期
        /// </summary>
        /// <param name="deliveryDateId"></param>
        /// <returns></returns>
        DeliveryDate GetDeliveryDateById(int deliveryDateId);

        /// <summary>
        /// 获取所有交货日期
        /// </summary>
        /// <returns></returns>
        IList<DeliveryDate> GetAllDeliveryDates();

        /// <summary>
        /// 插入交货日期
        /// </summary>
        /// <param name="deliveryDate"></param>
        void InsertDeliveryDate(DeliveryDate deliveryDate);

        /// <summary>
        /// 更新交货日期
        /// </summary>
        /// <param name="deliveryDate"></param>
        void UpdateDeliveryDate(DeliveryDate deliveryDate);


        /// <summary>
        /// 获取获得产品可用性范围
        /// </summary>
        /// <param name="productAvailabilityRangeId"></param>
        /// <returns></returns>
        ProductAvailabilityRange GetProductAvailabilityRangeById(int productAvailabilityRangeId);

        /// <summary>
        /// 获取所有可用性范围
        /// </summary>
        /// <returns></returns>
        IList<ProductAvailabilityRange> GetAllProductAvailabilityRanges();

        /// <summary>
        /// 插入可用性范围
        /// </summary>
        /// <param name="productAvailabilityRange"></param>
        void InsertProductAvailabilityRange(ProductAvailabilityRange productAvailabilityRange);

        /// <summary>
        /// 更新可用性范围
        /// </summary>
        /// <param name="productAvailabilityRange"></param>
        void UpdateProductAvailabilityRange(ProductAvailabilityRange productAvailabilityRange);

        /// <summary>
        /// 删除可用性范围
        /// </summary>
        /// <param name="productAvailabilityRange"></param>
        void DeleteProductAvailabilityRange(ProductAvailabilityRange productAvailabilityRange);

    }
}
