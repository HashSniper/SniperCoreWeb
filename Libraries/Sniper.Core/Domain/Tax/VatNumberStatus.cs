using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Tax
{
    /// <summary>
    /// 表示增值税号状态枚举
    /// </summary>
    public enum VatNumberStatus
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Empty
        /// </summary>
        Empty = 10,

        /// <summary>
        /// Valid
        /// </summary>
        Valid = 20,

        /// <summary>
        /// Invalid
        /// </summary>
        Invalid = 30
    }
}
