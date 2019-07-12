using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Authentication.External
{
    public interface IExternalAuthenticationRegistrar
    {
        void Configure(AuthenticationBuilder builder);
    }
}
