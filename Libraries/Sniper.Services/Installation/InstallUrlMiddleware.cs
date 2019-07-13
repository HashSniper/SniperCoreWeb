using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Installation
{
    public partial class InstallUrlMiddleware
    {
        #region Fileds
        private readonly RequestDelegate _next;
        #endregion

        #region Ctors
        public InstallUrlMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion
    }
}
