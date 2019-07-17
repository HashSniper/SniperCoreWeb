using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Stores
{
    public partial class StoreMapping : BaseEntity
    {
        /// <summary>
        /// 实体id
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// 实体名称
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// 商店id
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 商店
        /// </summary>
        public virtual Store Store { get; set; }

    }
}
