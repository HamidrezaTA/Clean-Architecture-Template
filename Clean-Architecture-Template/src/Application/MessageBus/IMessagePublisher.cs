using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.MessageBus
{
    public interface IMessagePublisher
    {
        void Publish();
    }
}