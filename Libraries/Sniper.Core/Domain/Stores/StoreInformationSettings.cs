using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Stores
{
    public class StoreInformationSettings:ISettings
    {
        /// <summary>
        /// 是否应显示“由nopCommerce提供支持”文本。
        /// </summary>
        public bool HidePoweredByNopCommerce { get; set; }

        /// <summary>
        /// 存储是否已关闭
        /// </summary>
        public bool StoreClosed { get; set; }

        /// <summary>
        /// 徽标的图片标识符。 如果为0，则使用默认值
        /// </summary>
        public int LogoPictureId { get; set; }

        /// <summary>
        /// 设置默认主题
        /// </summary>
        public string DefaultStoreTheme { get; set; }

        /// <summary>
        /// 是否允许客户选择主题
        /// </summary>
        public bool AllowCustomerToSelectTheme { get; set; }

        /// <summary>
        /// 是否应在公共存储中显示迷你探查器（用于调试）
        /// </summary>
        public bool DisplayMiniProfilerInPublicStore { get; set; }

        /// <summary>
        /// 是否应仅为有权访问管理区域的用户显示迷你探查器
        /// </summary>
        public bool DisplayMiniProfilerForAdminOnly { get; set; }

        /// <summary>
        /// 是否应显示有关新EU Cookie规则的警告
        /// </summary>
        public bool DisplayEuCookieLawWarning { get; set; }

        /// <summary>
        /// 获取或设置站点的Facebook页面URL的值
        /// </summary>
        public string FacebookLink { get; set; }

        /// <summary>
        /// TwitterLink
        /// </summary>
        public string TwitterLink { get; set; }

        /// <summary>
        /// YoutubeLink
        /// </summary>
        public string YoutubeLink { get; set; }
    }
}
