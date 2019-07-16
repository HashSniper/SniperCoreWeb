using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Logging
{
    public partial class ActivityLogType : BaseEntity
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string SystemKeyword { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enabled { get; set; }

    }
}
