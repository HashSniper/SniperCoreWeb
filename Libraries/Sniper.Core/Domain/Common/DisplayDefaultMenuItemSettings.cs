using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Common
{
    /// <summary>
    /// 显示默认菜单项设置
    /// </summary>
    public class DisplayDefaultMenuItemSettings : ISettings
    {
        /// <summary>
        /// 是否显示“主页”菜单项
        /// </summary>
        public bool DisplayHomepageMenuItem { get; set; }

        /// <summary>
        /// 是否显示“新产品”菜单项
        /// </summary>
        public bool DisplayNewProductsMenuItem { get; set; }

        /// <summary>
        /// 是否显示“产品搜索”菜单项
        /// </summary>
        public bool DisplayProductSearchMenuItem { get; set; }

        /// <summary>
        /// 是否显示“客户信息”菜单项
        /// </summary>
        public bool DisplayCustomerInfoMenuItem { get; set; }

        /// <summary>
        /// 是否显示“博客”菜单项
        /// </summary>
        public bool DisplayBlogMenuItem { get; set; }

        /// <summary>
        /// 是否显示“论坛”菜单项
        /// </summary>
        public bool DisplayForumsMenuItem { get; set; }

        /// <summary>
        /// 是否显示“联系我们”菜单项
        /// </summary>
        public bool DisplayContactUsMenuItem { get; set; }

    }
}
