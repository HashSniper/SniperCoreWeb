using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Configuration
{
    public partial class Setting : BaseEntity, ILocalizedEntity
    {
        public Setting()
        {
        }

        public Setting(string name, string value, int storeId = 0)
        {
            Name = name;
            Value = value;
            StoreId = storeId;
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public int StoreId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
