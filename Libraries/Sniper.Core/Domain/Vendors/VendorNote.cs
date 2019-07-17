using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Vendors
{
    public partial class VendorNote : BaseEntity
    {
        /// <summary>
        /// id
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// Note
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public virtual Vendor Vendor { get; set; }

    }
}
