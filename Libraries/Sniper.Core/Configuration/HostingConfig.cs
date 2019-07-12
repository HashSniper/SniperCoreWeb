using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Configuration
{
    public class HostingConfig
    {

        public string ForwardedHttpHeader { get; set; }

        public bool UseHttpClusterHttps { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use HTTP_X_FORWARDED_PROTO
        /// </summary>
        public bool UseHttpXForwardedProto { get; set; }
    }
}
