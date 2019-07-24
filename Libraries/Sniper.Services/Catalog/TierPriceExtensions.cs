using Sniper.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Infrastructure;

namespace Sniper.Services.Catalog
{
    public static class TierPriceExtensions
    {
        /// <summary>
        /// 按商店过滤层级价格
        /// </summary>
        /// <param name="source"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public static IEnumerable<TierPrice> FilterByStore(this IEnumerable<TierPrice> source, int storeId)
        {
            if(source==null)
                throw new ArgumentNullException(nameof(source));

            return source.Where(p => p.StoreId == 0 || p.StoreId == storeId);
        }

        /// <summary>
        /// 过滤客户的层级价格
        /// </summary>
        /// <param name="source"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static IEnumerable<TierPrice> FilterForCustomer(this IEnumerable<TierPrice> source, Customer customer)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var catalogSettings = EngineContext.Current.Resolve<CatalogSettings>();
            if (catalogSettings.IgnoreAcl)
                return source;

            var customerRoleIds = customer.GetCustomerRoleIds();

            return source.Where(p => !p.CustomerRoleId.HasValue || p.CustomerRoleId.Value == 0 || customerRoleIds.Contains(p.CustomerRoleId.Value));
        }

        /// <summary>
        /// 按日期过滤层级价格
        /// </summary>
        /// <param name="source"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static IEnumerable<TierPrice> FilterByDate(this IEnumerable<TierPrice> source, DateTime? date = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (!date.HasValue)
                date = DateTime.UtcNow;

            return source.Where(p => (!p.StartDateTimeUtc.HasValue || p.StartDateTimeUtc.Value < date) &&
            (!p.EndDateTimeUtc.HasValue || p.EndDateTimeUtc.Value > date));
        }

        /// <summary>
        /// 删除重复的数量（只保留最低价格的等级价格）
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<TierPrice> RemoveDuplicatedQuantities(this IEnumerable<TierPrice> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var tierPrices = source.ToList();

            var tierPricesWithDuplicates = tierPrices.GroupBy(p => p.Quantity).Where(g => g.Count() > 1);

            var duplicatedPrices = tierPricesWithDuplicates.SelectMany(g =>
              {
                  var minTierPrice = g.Aggregate((currentMinTierPrice, nextTierPrice) =>
                    {
                        return (currentMinTierPrice.Price < nextTierPrice.Price ? currentMinTierPrice : nextTierPrice);
                    });

                  return g.Where(p => p.Id != minTierPrice.Id);
              });

            return tierPrices.Where(tierPrice => duplicatedPrices.All(duplicatedPrice => duplicatedPrice.Id != tierPrice.Id));
        }
    }
}
