using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using Sniper.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Web.Framework.Mvc.Routing
{
    public class NopRedirectResultExecutor : RedirectResultExecutor
    {
        #region Fields

        private readonly SecuritySettings _securitySettings;

        #endregion

        #region Ctor

        public NopRedirectResultExecutor(ILoggerFactory loggerFactory,
            IUrlHelperFactory urlHelperFactory,
            SecuritySettings securitySettings) : base(loggerFactory, urlHelperFactory)
        {
            _securitySettings = securitySettings;
        }

        #endregion
    }
}
