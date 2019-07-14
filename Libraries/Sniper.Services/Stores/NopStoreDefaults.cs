﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Stores
{
    public static partial class NopStoreDefaults
    {
        #region Store mappings

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : entity ID
        /// {1} : entity name
        /// </remarks>
        public static string StoreMappingByEntityIdNameCacheKey => "Nop.storemapping.entityid-name-{0}-{1}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string StoreMappingPrefixCacheKey => "Nop.storemapping.";

        #endregion

        #region Stores

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static string StoresAllCacheKey => "Nop.stores.all";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : store ID
        /// </remarks>
        public static string StoresByIdCacheKey => "Nop.stores.id-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string StoresPrefixCacheKey => "Nop.stores.";

        #endregion
    }
}