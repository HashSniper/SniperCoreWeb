using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Events
{
    public partial class EventPublisher : IEventPublisher
    {
        public void Publish<TEvent>(TEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
