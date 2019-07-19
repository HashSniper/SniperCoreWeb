using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Shipping
{
    public partial class Warehouse : BaseEntity
    {
        public string Name { get; set; }
        public string AdminComment { get; set; }
        public int AddressId { get; set; }

    }
}
