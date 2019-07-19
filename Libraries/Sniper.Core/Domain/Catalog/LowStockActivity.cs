using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    public enum LowStockActivity
    {
        /// <summary>
        /// Nothing
        /// </summary>
        Nothing = 0,

        /// <summary>
        /// Disable buy button
        /// </summary>
        DisableBuyButton = 1,

        /// <summary>
        /// Unpublish
        /// </summary>
        Unpublish = 2,
    }
}
