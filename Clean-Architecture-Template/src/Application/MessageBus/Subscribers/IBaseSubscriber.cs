using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.MessageBus.Subscribers
{
    public interface IBaseSubscriber
    {
        void Handler();
    }
}