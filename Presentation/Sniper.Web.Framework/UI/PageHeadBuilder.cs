using BundlerMinifier;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Sniper.Core.Caching;
using Sniper.Core.Domain.Common;
using Sniper.Core.Domain.Seo;
using Sniper.Core.Infrastructure;
using Sniper.Services.Seo;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sniper.Web.Framework.UI
{
    public partial class PageHeadBuilder : IPageHeadBuilder
    {
        #region

        private static readonly object _lock = new object();

        private readonly BundleFileProcessor _processor;
        private readonly CommonSettings _commonSettings;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly INopFileProvider _fileProvider;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IUrlRecordService _urlRecordService;
        private readonly SeoSettings _seoSettings;

        private readonly List<string> _titleParts;
        private readonly List<string> _metaDescriptionParts;
        private readonly List<string> _metaKeywordParts;
        private readonly Dictionary<ResourceLocation, List<ScriptReferenceMeta>> _scriptParts;
        private readonly Dictionary<ResourceLocation, List<string>> _inlineScriptParts;
        private readonly Dictionary<ResourceLocation, List<CssReferenceMeta>> _cssParts;
        private readonly List<string> _canonicalUrlParts;
        private readonly List<string> _headCustomParts;
        private readonly List<string> _pageCssClassParts;
        private string _activeAdminMenuSystemName;
        private string _editPageUrl;

        //in minutes
        private const int RECHECK_BUNDLED_FILES_PERIOD = 120;

        #endregion

        #region Ctor

        public PageHeadBuilder(
            CommonSettings commonSettings,
            IActionContextAccessor actionContextAccessor,
            IHostingEnvironment hostingEnvironment,
            INopFileProvider fileProvider,
            IStaticCacheManager cacheManager,
            IUrlHelperFactory urlHelperFactory,
            IUrlRecordService urlRecordService,
            SeoSettings seoSettings
            )
        {
            _processor = new BundleFileProcessor();
            _commonSettings = commonSettings;
            _actionContextAccessor = actionContextAccessor;
            _hostingEnvironment = hostingEnvironment;
            _fileProvider = fileProvider;
            _cacheManager = cacheManager;
            _urlHelperFactory = urlHelperFactory;
            _urlRecordService = urlRecordService;
            _seoSettings = seoSettings;

            _titleParts = new List<string>();
            _metaDescriptionParts = new List<string>();
            _metaKeywordParts = new List<string>();
            _scriptParts = new Dictionary<ResourceLocation, List<ScriptReferenceMeta>>();
            _inlineScriptParts = new Dictionary<ResourceLocation, List<string>>();
            _cssParts = new Dictionary<ResourceLocation, List<CssReferenceMeta>>();
            _canonicalUrlParts = new List<string>();
            _headCustomParts = new List<string>();
            _pageCssClassParts = new List<string>();
        }

        #endregion

        #region Methods
        public void AddCanonicalUrlParts(string part)
        {
            throw new NotImplementedException();
        }

        public void AddCssFileParts(ResourceLocation location, string src, string debugSrc, bool excludeFromBundle = false)
        {
            throw new NotImplementedException();
        }

        public void AddEditPageUrl(string url)
        {
            throw new NotImplementedException();
        }

        public void AddHeadCustomParts(string part)
        {
            throw new NotImplementedException();
        }

        public void AddInlineScriptParts(ResourceLocation location, string script)
        {
            throw new NotImplementedException();
        }

        public void AddMetaDescriptionParts(string part)
        {
            throw new NotImplementedException();
        }

        public void AddMetaKeywordParts(string part)
        {
            throw new NotImplementedException();
        }

        public void AddPageCssClassParts(string part)
        {
            throw new NotImplementedException();
        }

        public void AddScriptParts(ResourceLocation location, string src, string debugSrc, bool excludeFromBundle, bool isAsync)
        {
            throw new NotImplementedException();
        }

        public void AddTitleParts(string part)
        {
            throw new NotImplementedException();
        }

        public void AppendCanonicalUrlParts(string part)
        {
            throw new NotImplementedException();
        }

        public void AppendCssFileParts(ResourceLocation location, string src, string debugSrc, bool excludeFromBundle = false)
        {
            throw new NotImplementedException();
        }

        public void AppendHeadCustomParts(string part)
        {
            throw new NotImplementedException();
        }

        public void AppendInlineScriptParts(ResourceLocation location, string script)
        {
            throw new NotImplementedException();
        }

        public void AppendMetaDescriptionParts(string part)
        {
            throw new NotImplementedException();
        }

        public void AppendMetaKeywordParts(string part)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="part"></param>
        public virtual void AppendPageCssClassParts(string part)
        {
            if (string.IsNullOrEmpty(part))
            {
                return;
            }

            _pageCssClassParts.Insert(0, part);
        }

        public void AppendScriptParts(ResourceLocation location, string src, string debugSrc, bool excludeFromBundle, bool isAsync)
        {
            throw new NotImplementedException();
        }

        public void AppendTitleParts(string part)
        {
            throw new NotImplementedException();
        }

        public string GenerateCanonicalUrls()
        {
            throw new NotImplementedException();
        }

        public string GenerateCssFiles(ResourceLocation location, bool? bundleFiles = null)
        {
            throw new NotImplementedException();
        }

        public string GenerateHeadCustom()
        {
            throw new NotImplementedException();
        }

        public string GenerateInlineScripts(ResourceLocation location)
        {
            throw new NotImplementedException();
        }

        public string GenerateMetaDescription()
        {
            throw new NotImplementedException();
        }

        public string GenerateMetaKeywords()
        {
            throw new NotImplementedException();
        }

        public string GeneratePageCssClasses()
        {
            throw new NotImplementedException();
        }

        public string GenerateScripts(ResourceLocation location, bool? bundleFiles = null)
        {
            throw new NotImplementedException();
        }

        public string GenerateTitle(bool addDefaultTitle)
        {
            throw new NotImplementedException();
        }

        public string GetActiveMenuItemSystemName()
        {
            throw new NotImplementedException();
        }

        public string GetEditPageUrl()
        {
            throw new NotImplementedException();
        }

        public void SetActiveMenuItemSystemName(string systemName)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Nested classes

        /// <summary>
        /// JS file meta data
        /// </summary>
        private class ScriptReferenceMeta : IEquatable<ScriptReferenceMeta>
        {
            /// <summary>
            /// A value indicating whether to exclude the script from bundling
            /// </summary>
            public bool ExcludeFromBundle { get; set; }

            /// <summary>
            /// A value indicating whether to load the script asynchronously 
            /// </summary>
            public bool IsAsync { get; set; }

            /// <summary>
            /// Src for production
            /// </summary>
            public string Src { get; set; }

            /// <summary>
            /// Src for debugging
            /// </summary>
            public string DebugSrc { get; set; }

            /// <summary>
            /// Equals
            /// </summary>
            /// <param name="item">Other item</param>
            /// <returns>Result</returns>
            public bool Equals(ScriptReferenceMeta item)
            {
                if (item == null)
                    return false;
                return Src.Equals(item.Src) && DebugSrc.Equals(item.DebugSrc);
            }
            /// <summary>
            /// Get hash code
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return Src == null ? 0 : Src.GetHashCode();
            }
        }

        /// <summary>
        /// CSS file meta data
        /// </summary>
        private class CssReferenceMeta : IEquatable<CssReferenceMeta>
        {
            public bool ExcludeFromBundle { get; set; }

            /// <summary>
            /// Src for production
            /// </summary>
            public string Src { get; set; }

            /// <summary>
            /// Src for debugging
            /// </summary>
            public string DebugSrc { get; set; }

            /// <summary>
            /// Equals
            /// </summary>
            /// <param name="item">Other item</param>
            /// <returns>Result</returns>
            public bool Equals(CssReferenceMeta item)
            {
                if (item == null)
                    return false;
                return Src.Equals(item.Src) && DebugSrc.Equals(item.DebugSrc);
            }
            /// <summary>
            /// Get hash code
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return Src == null ? 0 : Src.GetHashCode();
            }
        }

        #endregion

    }
}
