using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Data
{
    public partial interface IDataProviderManager
    {
        #region Properties

        /// <summary>
        /// Gets data provider
        /// </summary>
        IDataProvider DataProvider { get; }

        #endregion
    }
}
