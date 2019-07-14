using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Infrastructure.Mapper
{
    public interface IOrderedMapperProfile
    {
        int Order { get; }
    }
}
