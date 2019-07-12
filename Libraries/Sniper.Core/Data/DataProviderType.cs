using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sniper.Core.Data
{
    public enum DataProviderType
    {
        [EnumMember(Value ="")]
        Unknown,

        [EnumMember(Value ="sqlserver")]
        SqlServer
    }
}
