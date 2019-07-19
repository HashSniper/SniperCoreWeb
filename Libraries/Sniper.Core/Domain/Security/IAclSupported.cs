using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Security
{
    public partial interface IAclSupported
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is subject to ACL
        /// </summary>
        bool SubjectToAcl { get; set; }
    }
}
