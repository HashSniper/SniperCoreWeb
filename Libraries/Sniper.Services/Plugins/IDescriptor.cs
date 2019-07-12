using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Plugins
{
    public interface IDescriptor
    {
        string SystemName { get; set; }

        string FriendlyName { get; set; }
    }
}
