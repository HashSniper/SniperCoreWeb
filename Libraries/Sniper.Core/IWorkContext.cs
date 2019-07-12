using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Directory;
using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Tax;
using Sniper.Core.Domain.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core
{
    public interface IWorkContext
    {
        /// <summary>
        /// 
        /// </summary>
        Customer CurrentCustomer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Customer OriginalCustomerIfImpersonated { get; }

        /// <summary>
        /// 获取当前供应
        /// </summary>
        Vendor CurrentVendor { get; }

        /// <summary>
        /// 当前语言
        /// </summary>
        Language WorkingLanguage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Currency WorkingCurrency { get; set; }

        /// <summary>
        /// 税
        /// </summary>
        TaxDisplayType TaxDisplayType { get; set; }

        /// <summary>
        /// 是否为管理员
        /// </summary>
        bool IsAdmin { get; set; }

    }
}
