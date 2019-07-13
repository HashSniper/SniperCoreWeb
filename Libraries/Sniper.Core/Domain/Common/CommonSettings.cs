using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Common
{
    public class CommonSettings:ISettings
    {
        public CommonSettings()
        {
            IgnoreLogWordlist = new List<string>();
        }

        /// <summary>
        /// 联系人窗口是否有主题
        /// </summary>
        public bool SubjectFieldOnContactUsForm { get; set; }

        /// <summary>
        /// 联系人窗体是否有系统邮件 
        /// </summary>
        public bool UseSystemEmailForContactUsForm { get; set; }

        /// <summary>
        /// 是否使用存储过程来加载
        /// </summary>
        public bool UseStoredProcedureForLoadingCategories { get; set; }

        /// <summary>
        /// 在禁用javasecrpt是发出警告
        /// </summary>
        public bool DisplayJavaScriptDisabledWarning { get; set; }

        /// <summary>
        /// 是否支持全文搜索
        /// </summary>
        public bool UseFullTextSearch { get; set; }

        /// <summary>
        /// 全文搜索模式
        /// </summary>
        public FulltextSearchMode FullTextMode { get; set; }

        /// <summary>
        /// 是否记录404错误
        /// </summary>
        public bool Log404Errors { get; set; }

        /// <summary>
        /// 使用站点分隔符
        /// </summary>
        public string BreadcrumbDelimiter { get; set; }

        /// <summary>
        /// 是否应该呈现<meta http-equiv =“X-UA-Compatible”content =“IE = edge”/>标记
        /// </summary>
        public bool RenderXuaCompatible { get; set; }

        /// <summary>
        /// 获取或设置“X-UA-Compatible”META标记的值
        /// </summary>
        public string XuaCompatibleValue { get; set; }

        /// <summary>
        /// 在记录日志是需要忽略的关键词
        /// </summary>
        public List<string> IgnoreLogWordlist { get; set; }

        /// <summary>
        /// 是否应在新窗口中打开由BBCode编辑器生成的链接
        /// </summary>
        public bool BbcodeEditorOpenLinksInNewWindow { get; set; }

        /// <summary>
        /// 是否应在弹出窗口中打开“接受服务条款”链接。 如果禁用，则它们将在新页面上打开。
        /// </summary>
        public bool PopupForTermsOfServiceLinks { get; set; }

        /// <summary>
        /// jQuery迁移脚本日志记录是否处于活动状态
        /// </summary>
        public bool JqueryMigrateScriptLoggingActive { get; set; }

        /// <summary>
        /// 是否应支持以前的nopCommerce版本（它可以略微提高性能）
        /// </summary>
        public bool SupportPreviousNopcommerceVersions { get; set; }

        /// <summary>
        /// 指示是否压缩响应（默认情况下为gzip）。
        /// </summary>
        public bool UseResponseCompression { get; set; }

        /// <summary>
        /// 静态内容的“Cache-Control”标头值的值
        /// </summary>
        public string StaticFilesCacheControl { get; set; }

        /// <summary>
        /// 获取或设置favicon和app图标<head />代码的值
        /// </summary>
        public string FaviconAndAppIconsHeadCode { get; set; }

        /// <summary>
        /// 该值指示是否启用标记缩小
        /// </summary>
        public bool EnableHtmlMinification { get; set; }

        /// <summary>
        /// 指示是否启用了JS文件绑定和缩小
        /// </summary>
        public bool EnableJsBundling { get; set; }

        /// <summary>
        /// 指示是否启用了css文件绑定和缩小
        /// </summary>
        public bool EnableCssBundling { get; set; }

        /// <summary>
        /// 运行计划任务超时之前的时间长度（以毫秒为单位）。 设置null以使用默认值
        /// </summary>
        public int? ScheduleTaskRunTimeout { get; set; }

    }
}
