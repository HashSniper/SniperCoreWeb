using Sniper.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sniper.Services.Helpers
{
    public partial interface IDateTimeHelper
    {
        /// <summary>
        /// 根据其标识符从注册表中检索System.TimeZoneInfo对象。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TimeZoneInfo FindTimeZoneById(string id);

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones();

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        DateTime ConvertToUserTime(DateTime dt);

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sourceDateTimeKind"></param>
        /// <returns></returns>
        DateTime ConvertToUserTime(DateTime dt, DateTimeKind sourceDateTimeKind);

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sourceTimeZone"></param>
        /// <returns></returns>
        DateTime ConvertToUserTime(DateTime dt, TimeZoneInfo sourceTimeZone);

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sourceTimeZone"></param>
        /// <param name="destinationTimeZone"></param>
        /// <returns></returns>
        DateTime ConvertToUserTime(DateTime dt, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone);

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        DateTime ConvertToUtcTime(DateTime dt);

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sourceDateTimeKind"></param>
        /// <returns></returns>
        DateTime ConvertToUtcTime(DateTime dt, DateTimeKind sourceDateTimeKind);


        /// <summary>
        /// Converts the date and time to Coordinated Universal Time (UTC)
        /// </summary>
        /// <param name="dt">The date and time to convert.</param>
        /// <param name="sourceTimeZone">The time zone of dateTime.</param>
        /// <returns>A DateTime value that represents the Coordinated Universal Time (UTC) that corresponds to the dateTime parameter. The DateTime value's Kind property is always set to DateTimeKind.Utc.</returns>
        DateTime ConvertToUtcTime(DateTime dt, TimeZoneInfo sourceTimeZone);

        /// <summary>
        /// Gets a customer time zone
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>Customer time zone; if customer is null, then default store time zone</returns>
        TimeZoneInfo GetCustomerTimeZone(Customer customer);

        /// <summary>
        /// Gets or sets a default store time zone
        /// </summary>
        TimeZoneInfo DefaultStoreTimeZone { get; set; }

        /// <summary>
        /// Gets or sets the current user time zone
        /// </summary>
        TimeZoneInfo CurrentTimeZone { get; set; }
    }
}
