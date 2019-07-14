using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Infrastructure
{
    public interface IStartupTask
    {
        void Execute();

        int Order { get; }
    }
}
