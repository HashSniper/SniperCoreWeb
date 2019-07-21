using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Vendors
{
    /// <summary>
    /// 供应商设置
    /// </summary>
    public class VendorSettings : ISettings
    {
        /// <summary>
        /// 供应商页面大小选项使用的默认值（适用于新供应商）
        /// </summary>
        public string DefaultVendorPageSizeOptions { get; set; }

        /// <summary>
        /// 供应商中显示的供应商数量有多少
        /// </summary>
        public int VendorsBlockItemsToDisplay { get; set; }

        /// <summary>
        /// 是否在产品详细信息页面上显示供应商名称
        /// </summary>
        public bool ShowVendorOnProductDetailsPage { get; set; }

        /// <summary>
        /// 在订单详细信息页面上显示供应商名称
        /// </summary>
        public bool ShowVendorOnOrderDetailsPage { get; set; }

        /// <summary>
        /// 客户是否可以联系供应商
        /// </summary>
        public bool AllowCustomersToContactVendors { get; set; }

        /// <summary>
        /// 用户是否可以填写表单以成为新的供应商
        /// </summary>
        public bool AllowCustomersToApplyForVendorAccount { get; set; }

        /// <summary>
        /// 供应商是否必须在注册期间接受服务条款
        /// </summary>
        public bool TermsOfServiceEnabled { get; set; }

        /// <summary>
        /// 是否可以通过供应商在商店中进行高级搜索
        /// </summary>
        public bool AllowSearchByVendor { get; set; }

        /// <summary>
        /// 供应商是否可以编辑自己的信息（公共商店）
        /// </summary>
        public bool AllowVendorsToEditInfo { get; set; }

        /// <summary>
        /// 是否通知商店所有者供应商信息已更改
        /// </summary>
        public bool NotifyStoreOwnerAboutVendorInformationChange { get; set; }

        /// <summary>
        /// 每个供应商的最大产品数量
        /// </summary>
        public int MaximumProductNumber { get; set; }

        /// <summary>
        /// 是否允许供应商进口产品
        /// </summary>
        public bool AllowVendorsToImportProducts { get; set; }

    }
}
