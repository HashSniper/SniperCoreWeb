using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sniper.Web.Framework.UI
{
    /// <summary>
    /// 页头构建器
    /// </summary>
    public partial interface IPageHeadBuilder
    {
        /// <summary>
        /// 将标题元素添加到<！[CDATA [<head>]]>
        /// </summary>
        /// <param name="part"></param>
        void AddTitleParts(string part);

        /// <summary>
        /// 将标题元素添加到<！[CDATA [<head>]]>
        /// </summary>
        /// <param name="part"></param>
        void AppendTitleParts(string part);

        /// <summary>
        /// 生成所有标题部分
        /// </summary>
        /// <param name="addDefaultTitle"></param>
        /// <returns></returns>
        string GenerateTitle(bool addDefaultTitle);

        /// <summary>
        /// 将元描述元素添加到<！[CDATA [<head>]]>
        /// </summary>
        /// <param name="part"></param>
        void AddMetaDescriptionParts(string part);

        /// <summary>
        /// 将元描述元素添加到<！[CDATA [<head>]]>
        /// </summary>
        /// <param name="part"></param>
        void AppendMetaDescriptionParts(string part);

        /// <summary>
        /// 生成描述
        /// </summary>
        /// <returns></returns>
        string GenerateMetaDescription();

        /// <summary>
        /// 将meta关键字元素添加到<！[CDATA [<head>]]>
        /// </summary>
        /// <param name="part"></param>
        void AddMetaKeywordParts(string part);

        /// <summary>
        /// 将meta关键字元素添加到<！[CDATA [<head>]]>
        /// </summary>
        /// <param name="part"></param>
        void AppendMetaKeywordParts(string part);

        /// <summary>
        /// 生成meta关键字
        /// </summary>
        /// <returns></returns>
        string GenerateMetaKeywords();

        /// <summary>
        /// 添加script
        /// </summary>
        /// <param name="location"></param>
        /// <param name="src"></param>
        /// <param name="debugSrc"></param>
        /// <param name="excludeFromBundle"></param>
        /// <param name="isAsync"></param>
        void AddScriptParts(ResourceLocation location, string src, string debugSrc, bool excludeFromBundle, bool isAsync);

        /// <summary>
        /// 添加script
        /// </summary>
        /// <param name="location"></param>
        /// <param name="src"></param>
        /// <param name="debugSrc"></param>
        /// <param name="excludeFromBundle"></param>
        /// <param name="isAsync"></param>
        void AppendScriptParts(ResourceLocation location, string src, string debugSrc, bool excludeFromBundle, bool isAsync);

        /// <summary>
        /// 生成script
        /// </summary>
        /// <param name="location"></param>
        /// <param name="bundleFiles"></param>
        /// <returns></returns>
        string GenerateScripts(ResourceLocation location, bool? bundleFiles = null);

        /// <summary>
        /// 添加内联脚本元素
        /// </summary>
        /// <param name="location"></param>
        /// <param name="script"></param>
        void AddInlineScriptParts(ResourceLocation location, string script);

        /// <summary>
        /// 添加内联脚本元素
        /// </summary>
        /// <param name="location"></param>
        /// <param name="script"></param>
        void AppendInlineScriptParts(ResourceLocation location, string script);

        /// <summary>
        /// 生成内联script
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        string GenerateInlineScripts(ResourceLocation location);

        /// <summary>
        /// 添加样式部分
        /// </summary>
        /// <param name="location"></param>
        /// <param name="src"></param>
        /// <param name="debugSrc"></param>
        /// <param name="excludeFromBundle"></param>
        void AddCssFileParts(ResourceLocation location, string src, string debugSrc, bool excludeFromBundle = false);

        /// <summary>
        /// 添加样式部分
        /// </summary>
        /// <param name="location"></param>
        /// <param name="src"></param>
        /// <param name="debugSrc"></param>
        /// <param name="excludeFromBundle"></param>
        void AppendCssFileParts(ResourceLocation location, string src, string debugSrc, bool excludeFromBundle = false);

        /// <summary>
        /// 生成样式部分
        /// </summary>
        /// <param name="location"></param>
        /// <param name="bundleFiles"></param>
        /// <returns></returns>
        string GenerateCssFiles(ResourceLocation location, bool? bundleFiles = null);

        /// <summary>
        /// 将规范URL元素添加到<！[CDATA [<head>]]>
        /// </summary>
        /// <param name="part"></param>
        void AddCanonicalUrlParts(string part);

        /// <summary>
        /// 将规范URL元素添加到<！[CDATA [<head>]]>
        /// </summary>
        /// <param name="part"></param>
        void AppendCanonicalUrlParts(string part);

        /// <summary>
        /// 生成
        /// </summary>
        /// <returns></returns>
        string GenerateCanonicalUrls();

        /// <summary>
        /// 将任何自定义元素添加到<！[CDATA [<head>]]>元素
        /// </summary>
        /// <param name="part"></param>
        void AddHeadCustomParts(string part);

        /// <summary>
        /// 将任何自定义元素添加到<！[CDATA [<head>]]>元素
        /// </summary>
        /// <param name="part"></param>
        void AppendHeadCustomParts(string part);

        /// <summary>
        /// 生成头部自定义部分
        /// </summary>
        /// <returns></returns>
        string GenerateHeadCustom();

        /// <summary>
        /// 将CSS类添加到<！[CDATA [<head>]]>元素
        /// </summary>
        /// <param name="part"></param>
        void AddPageCssClassParts(string part);

        /// <summary>
        /// 将CSS类添加到<！[CDATA [<head>]]>元素
        /// </summary>
        /// <param name="part"></param>
        void AppendPageCssClassParts(string part);

        /// <summary>
        /// 生成class
        /// </summary>
        /// <returns></returns>
        string GeneratePageCssClasses();

        /// <summary>
        /// 指定“编辑页面”URL
        /// </summary>
        /// <param name="url"></param>
        void AddEditPageUrl(string url);

        /// <summary>
        /// 获取编辑页面url
        /// </summary>
        /// <returns></returns>
        string GetEditPageUrl();

        /// <summary>
        /// 指定应选择（扩展）的管理菜单项的系统名称
        /// </summary>
        /// <param name="systemName"></param>
        void SetActiveMenuItemSystemName(string systemName);

        /// <summary>
        /// 获取应选择（扩展）的管理菜单项的系统名称
        /// </summary>
        /// <returns></returns>
        string GetActiveMenuItemSystemName();


    }
}
