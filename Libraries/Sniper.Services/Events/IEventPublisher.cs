using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Events
{
    public partial interface IEventPublisher
    {
        void Publish<TEvent>(TEvent @event);

    }
}
