using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Stores
{
    public partial interface IStoreMappingSupported
    {
        /// <summary>
        /// 设置是否限制于某些存储区
        /// </summary>
        bool LimitedToStores { get; set; }
    }
}
