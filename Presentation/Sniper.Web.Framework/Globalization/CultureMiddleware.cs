using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
