using Microsoft.AspNetCore.Http;
using Sniper.Core;
using Sniper.Core.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Sniper.Web.Framework.Globalization
{
    public class CultureMiddleware
    {
        #region Fileds
        private readonly RequestDelegate _next;
        #endregion

        #region Ctor
        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region Methods
        public Task Invoke(Microsoft.AspNetCore.Http.HttpContext context, IWebHelper webHelper, IWorkContext workContext)
        {
            //set culture
            SetWorkingCulture(webHelper, workContext);

            //call the next middleware in the request pipeline
            return _next(context);
        }
        #endregion

        #region Utilities
        protected void SetWorkingCulture(IWebHelper webHelper, IWorkContext workContext)
        {
            if (!DataSettingsManager.DatabaseIsInstalled)
                return;

            if (webHelper.IsStaticResource())
                return;

            var adminAreaUrl = $"{webHelper.GetStoreLocation()}admin";
            if (webHelper.GetThisPageUrl(false).StartsWith(adminAreaUrl, StringComparison.InvariantCultureIgnoreCase))
            {
                CommonHelper.SetTelerikCulture();
                workContext.IsAdmin = true;
            }
            else
            {
                var culture = new CultureInfo(workContext.WorkingLanguage.LanguageCulture);
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }
        }
        #endregion
    }
}
