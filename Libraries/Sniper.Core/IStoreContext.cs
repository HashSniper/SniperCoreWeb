using Sniper.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core
{
    public interface IStoreContext
    {
        Store CurrentStore { get; }

        int ActiveStoreScopeConfiguration { get; }
    }
}
