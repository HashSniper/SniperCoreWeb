using Sniper.Core.Infrastructure;
using Sniper.Services.Localization;
using Sniper.Web.Framework.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Web.Framework.Mvc.Razor
{
    public abstract class NopRazorPage<TModel> : Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel>
    {
        private ILocalizationService _localizationService;

        private Localizer _localizer;


        public Localizer T
        {
            get
            {
                if (_localizationService == null)
                    _localizationService = EngineContext.Current.Resolve<ILocalizationService>();

                if (_localizer == null)
                {
                    _localizer = (format, args) =>
                      {
                          var resFormat = _localizationService.GetResource(format);

                          if (string.IsNullOrEmpty(resFormat))
                          {
                              return new LocalizedString(format);
                          }

                          return new LocalizedString((args == null || args.Length == 0) ? resFormat : string.Format(resFormat, args));
                      };
                }

                return _localizer;
            }
        }
    }
}
