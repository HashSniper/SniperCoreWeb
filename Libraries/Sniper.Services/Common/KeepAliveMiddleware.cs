using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Common
{
    public class KeepAliveMiddleware
    {
        #region Fileds
        private readonly RequestDelegate _next;
        #endregion

        #region Ctor
        public KeepAliveMiddleware(RequestDelegate request)
        {
            _next = request;
        }
        #endregion
    }
}
