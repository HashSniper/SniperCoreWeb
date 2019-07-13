using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Common
{
    public class AdminAreaSettings:ISettings
    {
        /// <summary>
        /// 默认页面大小
        /// </summary>
        public int DefaultGridPageSize { get; set; }

        /// <summary>
        /// 弹窗页面大小
        /// </summary>
        public int PopupGridPageSize { get; set; }

        /// <summary>
        /// 可用页面大小
        /// </summary>
        public string GridPageSizes { get; set; }

        /// <summary>
        /// 编辑器的其他设置
        /// </summary>
        public string RichEditorAdditionalSettings { get; set; }

        /// <summary>
        /// 编辑器是否支持javascript
        /// </summary>
        public bool RichEditorAllowJavaScript { get; set; }

        /// <summary>
        /// 编辑器是否支持 tag
        /// </summary>
        public bool RichEditorAllowStyleTag { get; set; }

        /// <summary>
        /// 是否用编辑器编辑客户邮件
        /// </summary>
        public bool UseRichEditorForCustomerEmails { get; set; }

        /// <summary>
        /// 是否用编辑器编辑消息模板
        /// </summary>
        public bool UseRichEditorInMessageTemplates { get; set; }

        /// <summary>
        /// 是否隐藏广告
        /// </summary>
        public bool HideAdvertisementsOnAdminArea { get; set; }

        /// <summary>
        /// 是否删除版权信息
        /// </summary>
        public bool CheckCopyrightRemovalKey { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string LastNewsTitleAdminArea { get; set; }

        /// <summary>
        /// 是否为Json格式
        /// </summary>
        public bool UseIsoDateFormatInJsonResult { get; set; }
    }
}
